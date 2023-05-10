using ProductsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProductsApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected virtual void Application_BeginRequest()
        {
            if (!HttpContext.Current.Items.Contains("_EntityContext"))
            {
                HttpContext.Current.Items["_EntityContext"] = new ProductsAppDBContext();
            }
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var entityContext = HttpContext.Current.Items["_EntityContext"] as ProductsAppDBContext;

            if (entityContext != null)
            {
                entityContext.Dispose();
            }
        }
    }
}
