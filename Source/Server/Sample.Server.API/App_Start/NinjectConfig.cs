[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Sample.Server.API.App_Start.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Sample.Server.API.App_Start.NinjectConfig), "Stop")]

namespace Sample.Server.API.App_Start
{
    using System;
    using System.Web;
    using Data.Contracts;
    using Data.Contexts;
    using Data.Common.Contracts;
    using Data.Common.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Services.Common.Contracts;
    using Sample.Common.Constants;

    public class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {

            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISampleDbContext>()
                .To<SampleDbContext>()
                .InRequestScope();

            kernel.Bind(typeof(IRepository<>))
                .To(typeof(EntityFrameworkGenericRepository<>));

            kernel.Bind(
                k => 
                    k.From(Assemblies.DataServices)
                    .SelectAllClasses()
                    .InheritedFrom(typeof(IService))
                    .BindDefaultInterface());
        }
    }
}