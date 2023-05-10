using ProductsApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace ProductsApplication.Helpers
{
    public class JSONHelper
    {
        private readonly string _jsonFilePath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        public JSONHelper(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public List<ProductViewModel> GetProductListFromJSON()
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            using (FileStream productsJSON = File.OpenRead(_jsonFilePath))
            {
                productViewModels = JsonSerializer.Deserialize<List<ProductViewModel>>(productsJSON, _options);
            }

            return productViewModels;
        }
    }
}