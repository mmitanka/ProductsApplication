using Newtonsoft.Json;
using ProductsApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsApplication.ViewModels
{
    public enum ProductCategory
    {
        Food = 0,
        Drinks = 1,
        Clothes = 2,
        Shoes = 3
    }

    public class ProductViewModel
    {
        #region  Properties

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("manufacturerName")]
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }

        [JsonProperty("supplierName")]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        public const string PATH_TO_PRODUCTS_JSON_FILE = "~/Content/products.json";

        #endregion Properties

        #region Constructors

        public ProductViewModel()
        {

        }

        public ProductViewModel(Product product)
        {
            Name = product.Name;
            Description = string.IsNullOrEmpty(product.Description) ? "" : product.Description;
            Category = ((ProductCategory)product.Category).ToString();
            ManufacturerName = product.Manufacturer.Name;
            SupplierName = product.Supplier.Name;
            Price = product.Price;
        }

        #endregion Constructors
    }
}