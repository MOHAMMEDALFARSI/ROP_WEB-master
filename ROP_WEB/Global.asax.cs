using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using System.Threading;


namespace ROP_WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest()
        {
            if (Request.Cookies["fav"] != null)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Request.Cookies["fav"].Value);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Request.Cookies["fav"].Value);

            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ar");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar");
               
            }
        }
    }
}
