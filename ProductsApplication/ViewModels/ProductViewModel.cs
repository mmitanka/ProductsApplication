using Newtonsoft.Json;
using ProductsApplication.Helpers;
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
        #region Properties

        public int ID { get; set; }

        [JsonProperty("name")]
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [JsonProperty("description")]
        [StringLength(250, ErrorMessage = "Description cannot be longer than 250 characters.")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public List<KeyValuePair<int, string>> CategoryList { get; set; }

        [JsonProperty("manufacturerName")]
        [Display(Name = "Manufacturer")]
        public string ManufacturerName { get; set; }

        [Required(ErrorMessage = "The Manufacturer field is required.")]
        public int ManufacturerID { get; set; }

        public List<KeyValuePair<int, string>> ManufacturerList { get; set; }

        [JsonProperty("supplierName")]
        [Display(Name = "Supplier")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "The Supplier field is required.")]
        public int SupplierID { get; set; }

        public List<KeyValuePair<int, string>> SupplierList { get; set; }

        [JsonProperty("price")]
        [Required]
        public double Price { get; set; }

        #endregion Properties

        #region Constructors

        public ProductViewModel()
        {

        }

        public ProductViewModel(Product product)
        {
            ID = product.ID;
            Name = product.Name;
            Description = string.IsNullOrEmpty(product.Description) ? "" : product.Description;
            Category = ((ProductCategory)product.Category).ToString();
            CategoryID = product.Category;
            ManufacturerName = product.Manufacturer.Name;
            ManufacturerID = product.ManufacturerID;
            SupplierName = product.Supplier.Name;
            SupplierID = product.SupplierID;
            Price = product.Price;
        }

        public ProductViewModel(List<Manufacturer> manufacturers, List<Supplier> suppliers)
        {
            CreateProductLists(manufacturers, suppliers);
        }

        #endregion Constructors

        #region Methods

        public void CreateProductLists(List<Manufacturer> manufacturers, List<Supplier> suppliers)
        {
            CategoryList = UtilHelper.CreateCategoryList();
            ManufacturerList = UtilHelper.CreateManufacturerList(manufacturers);
            SupplierList = UtilHelper.CreateSupplierList(suppliers);
        }

        #endregion Methods
    }
}