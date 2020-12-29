using System.Web.Mvc;
using System.Web.Routing;
namespace StackOverflowClone.CustomsFilter
{
    public class UserAuthorizationFilterAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext authorizationContext)
        {
            if (authorizationContext.RequestContext.HttpContext.Session["CurrentUserName"] == null)
            {
                authorizationContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "account", action = "login" }));
            }
        }

    }
}