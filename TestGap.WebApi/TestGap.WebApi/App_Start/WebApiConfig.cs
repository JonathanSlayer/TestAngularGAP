using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
namespace TestGap.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var domines = ConfigurationManager.AppSettings["allowDomines"];
            var cors = new EnableCorsAttribute(domines, "*", "*");
            config.EnableCors(cors);
            // Web API routes

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "services/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.Routes.MapHttpRoute(
              name: "ActionApi1",
              routeTemplate: "services/{action}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "services/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
