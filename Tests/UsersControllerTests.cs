namespace Tests
{
    using System.Web.Http.Results;
    using FluentAssertions;
    using NSubstitute;
    using WebApi;
    using WebApi.Controllers;
    using Xunit;

    public class UsersControllerTests
    {
        [Fact]
        public void should_say_hello_from_server()
        {
            //Arrange
            var hello = Substitute.For<IHello>();
            hello.SayHello("Sasha").Returns("Hello Sasha");
            var controller = new UsersController(hello);

            //Act
            var result = controller.Get() as OkNegotiatedContentResult<string>; 

            //Assert     
            result.Should().NotBeNull();
            result.Content.Should().Be("Hello Sasha");
        }
    }
}
