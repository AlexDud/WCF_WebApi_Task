namespace Tests
{
    using System;
    using System.Web.Http.Results;
    using FluentAssertions;
    using NSubstitute;
    using Ploeh.AutoFixture;
    using WebApi.Controllers;
    using WebApi.DAL.Contracts;
    using WebApi.DTOs;
    using WebApi.Models;
    using Xunit;

    public class UsersControllerTests
    {
        [Fact]
        public void should_add_new_user_to_db()
        {
            //Arrange
            var userDto = new Fixture().Create<UserDto>();
            var uow = Substitute.For<IUnitOfWork>();
            var controller = new UsersController(uow);

            //Act
            var result = controller.Post(userDto) as OkResult;

            //Assert     
            result.Should().NotBeNull();
            uow.Received().Save();
            uow.UserRepository.Received()
                .Insert(Arg.Is<User>(x => x.Name == userDto.UserName && x.Company.Name == userDto.CompanyName));
        }

        [Fact]
        public void should_not_add_new_user_when_exception_was_thrown()
        {
            //Arrange
            var userDto = new Fixture().Create<UserDto>();
            var uow = Substitute.For<IUnitOfWork>();
            var controller = new UsersController(uow);
            uow.When(x => x.Save()).Do(x => { throw new Exception(); });

            //Act
            var result = controller.Post(userDto) as ExceptionResult;

            //Assert     
            result.Should().NotBeNull();
        }
    }
}