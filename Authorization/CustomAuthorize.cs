
using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Mvc;

public class CustomizeAuthorize : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        if (httpContext == null)
        {
            throw new ArgumentNullException("httpContext");
        }
        IPrincipal user = httpContext.User;

        //if (!user.Identity.IsAuthenticated)
        if (HttpContext.Current.Session["UserName"] == null)
        {
            return false;
        }

        //if ((this._rolesSplit.Length > 0) && !this._rolesSplit.Any<string>(new Func<string, bool>(user.IsInRole)))
        //{
        //    return false;
        //}

        if ((this.Roles.Length > 0) && (!this.Roles.Contains(HttpContext.Current.Session["userrole"].ToString())))
        {
            return false;
        }


        return true;
    }
}