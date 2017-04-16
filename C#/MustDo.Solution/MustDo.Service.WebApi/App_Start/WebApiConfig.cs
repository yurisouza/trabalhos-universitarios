﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MustDo.Service.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Libera o acesso para qualquer host
            //(origins: "http://www.example.com", headers: "*", methods: "get,post")
            var cors = new EnableCorsAttribute("http://mustdo-webapi.azurewebsites.net/", "*", "*");
            config.EnableCors(cors);


            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional}
            );

            //config.Routes.MapHttpRoute(
            //    name: "Personalizada",
            //    routeTemplate: "api/{controller}/{id}/{action}"
            //);
        }
    }
}