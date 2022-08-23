using FitemaEntity.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FitemaAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private string _role;

        public AuthorizeAttribute()
        {
        }
        public AuthorizeAttribute(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (Users)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            if (!string.IsNullOrEmpty(_role))
            {
                if (user.Role.ToLower() != _role.ToLower())
                {
                    // not logged in
                    context.Result = new JsonResult(new { message = "Not Allowed" }) { StatusCode = StatusCodes.Status401Unauthorized };
                }
            }
        }
    }
}
