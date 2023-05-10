using ProductsApplication.Models;
using ProductsApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApplication.Helpers
{
    public static class UtilHelper
    {
        public const string PATH_TO_PRODUCTS_JSON_FILE = "~/Content/products.json";

        public static List<KeyValuePair<int, string>> CreateCategoryList()
        {
            List<KeyValuePair<int, string>> categoryList = new List<KeyValuePair<int, string>>();
            Array categoryTypes = Enum.GetValues(typeof(ProductCategory));

            foreach (var categoryType in categoryTypes)
            {
                string categpryName = Enum.GetName(typeof(ProductCategory), categoryType);

                categoryList.Add(new KeyValuePair<int, string>((int)categoryType, categpryName));
            }

            return categoryList;
        }

        public static List<KeyValuePair<int, string>> CreateManufacturerList(List<Manufacturer> manufacturers)
        {
            List<KeyValuePair<int, string>> manufacturerList = new List<KeyValuePair<int, string>>();

            foreach(var manufacturer in manufacturers)
            {
                manufacturerList.Add(new KeyValuePair<int, string>(manufacturer.ID, manufacturer.Name));
            }

            return manufacturerList;
        }

        public static List<KeyValuePair<int, string>> CreateSupplierList(List<Supplier> suppliers)
        {
            List<KeyValuePair<int, string>> supplierList = new List<KeyValuePair<int, string>>();

            foreach(var supplier in suppliers)
            {
                supplierList.Add(new KeyValuePair<int, string>(supplier.ID, supplier.Name));
            }

            return supplierList;
        }
    }
}