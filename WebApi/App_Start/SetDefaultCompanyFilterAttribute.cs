namespace WebApi.App_Start
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Contracts;

    public class SetDefaultCompanyFilterAttribute : ActionFilterAttribute
    {
        private const string DefaultCompanyName = "Microsoft";

        public override Task OnActionExecutingAsync(HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var key = "dto";
                object user;
                actionContext.ActionArguments.TryGetValue(key, out user);

                if (user == null)
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                        $"Cannot find action method parameter '{key}'");
                }
                else
                {
                    var userDto = user as UserDto;
                    if (userDto != null)
                    {
                        userDto.CompanyName = DefaultCompanyName;
                        actionContext.ActionArguments[key] = userDto;
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                            $"Wrong parameter data type. Should be {nameof(UserDto)}");
                    }
                }
            });
        }
    }
}