namespace Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using Contracts;
    using FluentAssertions;
    using WebApi.App_Start;
    using Xunit;

    public class SetDefaultCompanyFilterAttributeTests
    {
        [Fact]
        public async Task should_set_default_company_name()
        {
            //Arrange
            var key = "dto";
            var context = new HttpActionContext();
            context.ActionArguments.Add(key, new UserDto {UserName = "TestUser"});
            var attribute = new SetDefaultCompanyFilterAttribute();

            //Act
            await attribute.OnActionExecutingAsync(context, CancellationToken.None);

            //Assert
            var userDto = context.ActionArguments[key] as UserDto;
            userDto.Should().NotBeNull();
            userDto.CompanyName.Should().Be("Microsoft");
        }

        [Fact]
        public async Task should_not_set_default_company_name_if_parameter_name_is_not_valid()
        {
            //Arrange
            var context = new HttpActionContext
            {
                ControllerContext = new HttpControllerContext { Request = new HttpRequestMessage() }
            };
            context.ActionArguments.Add("dtoUser", new UserDto {UserName = "TestUser"});
            var attribute = new SetDefaultCompanyFilterAttribute();

            //Act
            await attribute.OnActionExecutingAsync(context, CancellationToken.None);

            //Assert
            context.Response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task should_not_set_default_company_name_if_parameter_type_is_not_valid()
        {
            //Arrange
            var context = new HttpActionContext
            {
                ControllerContext = new HttpControllerContext { Request = new HttpRequestMessage() }
            };
            context.ActionArguments.Add("dto", "New User");
            var attribute = new SetDefaultCompanyFilterAttribute();

            //Act
            await attribute.OnActionExecutingAsync(context, CancellationToken.None);

            //Assert
            context.Response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}