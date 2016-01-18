namespace CompanySystem.Server.API
{
    using App_Start;
    using System.Web.Http;
    using System.Reflection;
    using CompanySystem.Common.Constants;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.ServerDataTransferModels));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}