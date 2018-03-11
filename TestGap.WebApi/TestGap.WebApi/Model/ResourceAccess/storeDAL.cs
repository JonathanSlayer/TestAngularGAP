using System;
using System.Collections.Generic;
using System.Web;
using TestGap.WebApi.Model.businessEntities;
using System.IO;
using Newtonsoft.Json;

namespace TestGap.WebApi.Model.ResourceAccess
{
    public class StoreDAL
    {
        internal IList<Store> getStores()
        {
            string dir = HttpContext.Current.Server.MapPath("~/App_Data/stores.json");           
            using (StreamReader r = new StreamReader(dir))
            {
                string json = r.ReadToEnd();
                IList<Store> stores = JsonConvert.DeserializeObject<List<Store>>(json);
                return stores;
            }
        }
    }
}