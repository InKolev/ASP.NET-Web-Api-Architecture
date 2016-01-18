namespace CompanySystem.Server.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Microsoft.Owin.Security.OAuth;
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static HttpConfiguration Configuration { get; private set; }

        public static void Register(HttpConfiguration configuration)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            configuration.SuppressDefaultHostAuthentication();
            configuration.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional }
            );

            Configuration = configuration;
        }

        private static void EnableCrossSiteRequests(HttpConfiguration configuration)
        {
            configuration.EnableCors();
        }
    }
}