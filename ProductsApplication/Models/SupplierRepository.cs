using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApplication.Models
{
    public class SupplierRepository
    {
        #region Members

        private ProductsAppDBContext storeDB = null;

        #endregion Members

        #region Constructors

        public SupplierRepository()
        {
            storeDB = ContextProvider.GetContext();
        }

        #endregion Constructors

        #region Methods

        public List<Supplier> GetSuppliers()
        {
            return storeDB.Suppliers.ToList();
        }

        #endregion Methods
    }
}