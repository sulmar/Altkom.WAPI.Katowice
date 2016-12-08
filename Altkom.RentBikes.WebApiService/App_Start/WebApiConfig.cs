using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using FluentValidation.WebApi;
using Altkom.RentBikes.WebApiService.Handlers;
using Altkom.RentBikes.WebApiService.Formatters;

namespace Altkom.RentBikes.WebApiService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MessageHandlers.Add(new TraceMessageHandler());
            config.MessageHandlers.Add(new ApiKeyHandler());


            config.Formatters.Add(new QrCodeMediaTypeFormatter());

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
