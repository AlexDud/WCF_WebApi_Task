namespace WebApi.Controllers
{
    using System.Web.Http;

    [RoutePrefix("api/v1/users")]
    public class UsersController : ApiController
    {
        private readonly IHello hello;

        public UsersController(IHello hello)
        {
            this.hello = hello;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var message = hello.SayHello("Sasha");
            return Ok(message);
        }

        [Route("add")]
        public IHttpActionResult Post()
        {
            return Ok("User added");
        }
    }
}