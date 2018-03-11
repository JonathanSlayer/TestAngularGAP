
using System.Collections.Generic;
namespace TestGap.WebApi.Model.businessEntities
{
    public class Store
    {
        public int id { get; set; }
        public string address { get; set; }
        public string name { get; set; }
    }
    public class Stores
    {
        public IList<Store> stores { get; set; }
    }

}