namespace WebApi
{
    using System.Web.Http;
    using App_Start;
    using Microsoft.Practices.Unity.WebApi;

    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
        }
    }
}