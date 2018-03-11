namespace TestGap.WebApi.Model.businessEntities
{
    public class Articles
    {
        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int total_in_shelf { get; set; }
        public int total_in_vault { get; set; }
        public string store_name { get; set; }
        public int store_id { get; set; }
        
    }
}