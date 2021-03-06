using Admin.Entity;
using Admin.Models.Helper;
using System.Web;
using System.Web.Mvc;

namespace Admin.Filters
{
    public class SessionControlFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string urlLogin = "~/Login/Index";

            if (HttpContext.Current.Request.FilePath == "/Login/Index")
            {
                return;
            }

            if (HttpContext.Current.Session[Constants.SessionInformation] == null)
            {
                HttpContext.Current.Response.Redirect(urlLogin);
            }
            else
            {
                var user = (User)HttpContext.Current.Session[Constants.SessionInformation];
                if (user == null)
                    HttpContext.Current.Response.Redirect(urlLogin);
            }
        }
    }
}