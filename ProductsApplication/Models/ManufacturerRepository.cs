using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApplication.Models
{
    public class ManufacturerRepository
    {
        #region Members

        private ProductsAppDBContext storeDB = null;

        #endregion Members

        #region Constructors

        public ManufacturerRepository()
        {
            storeDB = ContextProvider.GetContext();
        }

        #endregion Constructors

        #region Methods

        public List<Manufacturer> GetManufacturers()
        {
            return storeDB.Manufacturers.ToList();
        }

        #endregion Methods
    }
}