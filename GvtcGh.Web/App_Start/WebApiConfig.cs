using System.Net.Http.Headers;
using System.Web.Http;

namespace GvtcGh.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Repository By User and Id",
                routeTemplate: "api/{controller}/{username}/{id}"
            );

            config.Routes.MapHttpRoute(
                name: "Repository By User",
                routeTemplate: "api/{controller}/{username}"
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
