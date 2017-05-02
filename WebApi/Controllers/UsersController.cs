namespace WebApi.Controllers
{
    using System.Web.Http;

    [RoutePrefix("api/v1/users")]
    public class UsersController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("All users were retrieved");
        }

        [Route("add")]
        public IHttpActionResult Post()
        {
            return Ok("User added");
        }
    }
}