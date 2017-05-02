namespace WebApi.Configuration
{
    using System.Web.Http;
    using Microsoft.Practices.Unity;

    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var container = new UnityContainer();

            container.RegisterType<IHello, Hello>(new TransientLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}