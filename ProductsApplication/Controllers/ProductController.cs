using ProductsApplication.Helpers;
using ProductsApplication.Models;
using ProductsApplication.ViewModels;
using System;
using System.Collections.Generic;
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
            JSONHelper JSONHelper = new JSONHelper(HostingEnvironment.MapPath(UtilHelper.PATH_TO_PRODUCTS_JSON_FILE));
            List<ProductViewModel> productViewModels = JSONHelper.GetProductListFromJSON();

            return View(productViewModels);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            ProductViewModel productViewModel = new ProductViewModel(_context);

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductViewModel productViewModel)
        {
            if(ModelState.IsValid)
            {
                Product product = new Product(productViewModel);

                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // Product is not created, errors exist
            productViewModel.CreateProductLists(_context);

            return View(productViewModel);
        }

        [HttpGet]
        public ActionResult EditProduct(int productID)
        {
            Product product = _context.Products.Where(p => p.ID == productID).FirstOrDefault();

            if(product != null)
            {
                ProductViewModel productViewModel = new ProductViewModel(product);

                productViewModel.CreateProductLists(_context);

                return View(productViewModel);
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        [HttpPost]
        public ActionResult EditProduct(ProductViewModel productViewModel)
        {
            Product product = _context.Products.Where(p => p.ID == productViewModel.ID).FirstOrDefault();

            if(product != null)
            {
                if (ModelState.IsValid)
                {
                    product.Name = productViewModel.Name;
                    product.Description = productViewModel.Description;
                    product.Category = productViewModel.CategoryID;
                    product.ManufacturerID = productViewModel.ManufacturerID;
                    product.SupplierID = productViewModel.SupplierID;
                    product.Price = product.Price;

                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }

                // Product is not edited, errors exist
                productViewModel.CreateProductLists(_context);

                return View(productViewModel);
            }

            return View("~/Views/Shared/Error.cshtml");
        }
    }
}