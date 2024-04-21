using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using StudentManagement.Models;

namespace StudentManagement.Presentation.Filters
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly int _role;

        public RoleAuthorizeAttribute(int role)
        {
            _role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var sessionObj = context.HttpContext.Session.GetString("loginDeatils");
            if (string.IsNullOrEmpty(sessionObj))
            {
                context.Result = new RedirectToActionResult("login", "Account", null);
                return;
            }
            var loginDetails = JsonConvert.DeserializeObject<LoginVM>(sessionObj);
            if (loginDetails!.Role != _role)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
