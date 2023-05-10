using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApplication.Models
{
    public class ContextProvider
    {
        public static ProductsAppDBContext GetContext()
        {
            return HttpContext.Current.Items["_EntityContext"] as ProductsAppDBContext;
        }
    }
}