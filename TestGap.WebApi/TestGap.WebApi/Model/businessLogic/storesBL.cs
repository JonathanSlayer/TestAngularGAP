
using System.Collections.Generic;
using TestGap.WebApi.Model.businessEntities;
using TestGap.WebApi.Model.ResourceAccess;

namespace TestGap.WebApi.Model.businessLogic
{
    public class StoresBL
    {
        /// <summary>
        /// Rturn all stores
        /// </summary>
        /// <returns></returns>
        internal IList<Store> getStores()
        {
            return new StoreDAL().getStores();
        }
    }

   
}