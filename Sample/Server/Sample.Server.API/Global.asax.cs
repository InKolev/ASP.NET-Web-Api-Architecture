namespace Sample.Server.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App_Start;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            //AutoMapperConfig.RegisterMappings(Assembly.Load("NeighboursCommunitySystem.Server.DataTransferModels"));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}