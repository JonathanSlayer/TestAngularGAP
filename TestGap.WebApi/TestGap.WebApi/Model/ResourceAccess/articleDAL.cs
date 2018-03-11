using System.Collections.Generic;
using System.Web;
using TestGap.WebApi.Model.businessEntities;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace TestGap.WebApi.Model.ResourceAccess
{
    public class ArticleDAL
    {
        internal IList<Articles> getArticles()
        {
            string dir = HttpContext.Current.Server.MapPath("~/App_Data/articles.json");
            using (StreamReader r = new StreamReader(dir))
            {
                string json = r.ReadToEnd();
                IList<Articles> articles = JsonConvert.DeserializeObject<List<Articles>>(json);
                return articles;
            }
        }

        internal IList<Articles> getArticlesByStoreId(int strore_id)
        {
            string dir = HttpContext.Current.Server.MapPath("~/App_Data/articles.json");
            using (StreamReader r = new StreamReader(dir))
            {
                string json = r.ReadToEnd();
                IList<Articles> articles = JsonConvert.DeserializeObject<List<Articles>>(json).Where(a => a.store_id == strore_id).ToList();
                return articles;
            }
        }
    }
}