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
        private readonly ProductsRepository productsRepository = new ProductsRepository();
        private readonly ManufacturerRepository manufacturerRepository = new ManufacturerRepository();
        private readonly SupplierRepository supplierRepository = new SupplierRepository();

        [HttpGet]
        public ActionResult Index()
        {
            List<Product> productList = productsRepository.GetProducts();
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
            List<Manufacturer> manufacturers = manufacturerRepository.GetManufacturers();
            List<Supplier> suppliers = supplierRepository.GetSuppliers();

            ProductViewModel productViewModel = new ProductViewModel(manufacturers, suppliers);

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductViewModel productViewModel)
        {
            if(ModelState.IsValid)
            {
                productsRepository.CreateProduct(productViewModel);

                return RedirectToAction("Index");
            }

            // Product is not created, errors exist
            List<Manufacturer> manufacturers = manufacturerRepository.GetManufacturers();
            List<Supplier> suppliers = supplierRepository.GetSuppliers();

            productViewModel.CreateProductLists(manufacturers, suppliers);

            return View(productViewModel);
        }

        [HttpGet]
        public ActionResult EditProduct(int productID)
        {
            Product product = productsRepository.Get(productID);

            if(product != null)
            {
                List<Manufacturer> manufacturers = manufacturerRepository.GetManufacturers();
                List<Supplier> suppliers = supplierRepository.GetSuppliers();
                ProductViewModel productViewModel = new ProductViewModel(product);

                productViewModel.CreateProductLists(manufacturers, suppliers);

                return View(productViewModel);
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        [HttpPost]
        public ActionResult EditProduct(ProductViewModel productViewModel)
        {
            Product product = productsRepository.Get(productViewModel.ID);

            if(product != null)
            {
                if (ModelState.IsValid)
                {
                    productsRepository.EditProduct(product, productViewModel);

                    return RedirectToAction("Index");
                }

                // Product is not edited, errors exist
                List<Manufacturer> manufacturers = manufacturerRepository.GetManufacturers();
                List<Supplier> suppliers = supplierRepository.GetSuppliers();

                productViewModel.CreateProductLists(manufacturers, suppliers);

                return View(productViewModel);
            }

            return View("~/Views/Shared/Error.cshtml");
        }
    }
}