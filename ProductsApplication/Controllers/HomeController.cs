using ProductsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsApplication.Controllers
{
    public class HomeController : Controller
    {
        ProductsAppDBContext context = new ProductsAppDBContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}