namespace WebApi.Controllers
{
    using System;
    using System.Web.Http;
    using App_Start;
    using Contracts;
    using DAL.Contracts;
    using Models;

    [RoutePrefix("api/v1/users")]
    public class UsersController : ApiController
    {
        private readonly IUnitOfWork uow;

        public UsersController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [Route("add")]
        [SetDefaultCompanyFilter]
        public IHttpActionResult Post(UserDto dto)
        {
            try
            {
                var user = new User
                {
                    Name = dto.UserName,
                    Company = new Company { Name = dto.CompanyName }
                };

                uow.UserRepository.Insert(user);
                uow.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }    
        }
    }
}