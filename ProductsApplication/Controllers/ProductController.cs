using Newtonsoft.Json;
using ProductsApplication.Helpers;
using ProductsApplication.Models;
using ProductsApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace ProductsApplication.Controllers
{
    public class ProductController : Controller
    {
        ProductsAppDBContext _context = new ProductsAppDBContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Product> productList = _context.Products.ToList();
            List<ProductViewModel> productViewModelList = new List<ProductViewModel>();

            foreach (var product in productList)
            {
                var viewModel = new ProductViewModel(product);

                productViewModelList.Add(viewModel);
            }

            return View(productViewModelList);
        }

        [HttpGet]
        public ActionResult GetProductsFromJSON()
        {
            JSONHelper JSONHelper = new JSONHelper(HostingEnvironment.MapPath(ProductViewModel.PATH_TO_PRODUCTS_JSON_FILE));
            List<ProductViewModel> productViewModels = JSONHelper.GetProductListFromJSON();

            return View(productViewModels);
        }
    }
}