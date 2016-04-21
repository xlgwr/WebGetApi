using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using WebGetApi.Filters;

namespace WebGetApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            config.SuppressDefaultHostAuthentication();

            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Filters.Add(new WebApiExceptionFilter());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "DefaultApiByTowKey",
            routeTemplate: "api/{controller}/{id}/{id2}/{id3}/{id4}/{id5}/{id6}",
            defaults: new
            {
                id = RouteParameter.Optional,
                id2 = RouteParameter.Optional,
                id3 = RouteParameter.Optional,
                id4 = RouteParameter.Optional,
                id5 = RouteParameter.Optional,
                id6 = RouteParameter.Optional
            }
             );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
