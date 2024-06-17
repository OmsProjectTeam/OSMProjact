using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

public class CustomAuthorizeFilter : IAuthorizationFilter
{
	public void OnAuthorization(AuthorizationFilterContext context)
	{
		if (!context.HttpContext.User.Identity.IsAuthenticated)
		{
			context.Result = new JsonResult(new { message = "Unauthorize! pleace login " })
			{
				StatusCode = StatusCodes.Status401Unauthorized
			};
		}
	}
}
