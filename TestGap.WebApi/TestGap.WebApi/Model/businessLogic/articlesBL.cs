
using System.Collections.Generic;
using TestGap.WebApi.Model.businessEntities;
using TestGap.WebApi.Model.ResourceAccess;

namespace TestGap.WebApi.Model.businessLogic
{
    public class ArticlesBL
    {
        /// <summary>
        /// Returns all articles 
        /// </summary>
        /// <returns></returns>
        internal IList<Articles> getArticles()
        {
            return new ArticleDAL().getArticles();
        }

        /// <summary>
        /// Return a list of articles by store_id
        /// </summary>
        /// <param name="strore_id"></param>
        /// <returns></returns>
        internal IList<Articles> getArticlesByStoreId(int strore_id)
        {
            return new ArticleDAL().getArticlesByStoreId(strore_id);
        }
        
    }
}