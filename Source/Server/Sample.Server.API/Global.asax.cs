namespace Sample.Server.API
{
    using System.Web.Http;
    using App_Start;
    using System.Reflection;
    using Sample.Common.Constants;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();

            // TODO: Rename assembly string "ServerDataTransferModels".
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.ServerDataTransferModels));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}