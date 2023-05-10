using ProductsApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApplication.Models
{
    public class ProductsRepository
    {
        #region Members

        private ProductsAppDBContext storeDB = null;

        #endregion Members

        #region Constructors

        public ProductsRepository()
        {
            storeDB = ContextProvider.GetContext();
        }

        #endregion Constructors

        #region Methods

        public Product Get(int ID)
        {
            return storeDB.Products.Where(p => p.ID == ID).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return storeDB.Products.ToList();
        }

        public void CreateProduct(ProductViewModel productViewModel)
        {
            Product product = new Product(productViewModel);

            if(product != null)
            {
                storeDB.Products.Add(product);
                Save();
            }
        }

        public void EditProduct(Product product, ProductViewModel productViewModel)
        {
            product.Name = productViewModel.Name;
            product.Description = productViewModel.Description;
            product.Category = productViewModel.CategoryID;
            product.ManufacturerID = productViewModel.ManufacturerID;
            product.SupplierID = productViewModel.SupplierID;
            product.Price = product.Price;

            Save();
        }

        public void Save()
        {
            storeDB.SaveChanges();
        }

        #endregion Methods
    }
}