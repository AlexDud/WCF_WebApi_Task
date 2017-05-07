namespace Tests
{
    using System.Linq;
    using System.Reflection;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using WebApi.App_Start;
    using WebApi.Controllers;
    using Xunit;

    public class UnityConfigTests
    {
        [Fact]
        public void should_resolve_all_dependencies_from_WebApi_assembly()
        {
            var container = UnityConfig.GetConfiguredContainer();

            //(t.IsAbstract && t.IsSealed) - check for filter static classes because they are IsAbstract and IsSealed
            var registeredTypes =
                Assembly.GetAssembly(typeof(UsersController))
                    .Types()
                    .Where(t => t.Namespace.StartsWith("WebApi") && (t.IsInterface || (t.IsAbstract && !t.IsSealed)));
    
            foreach (var type in registeredTypes.ToArray())
            {
                container.IsRegistered(type).Should().BeTrue();
            }
        }
    }
}