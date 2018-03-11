
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using TestGap.WebApi.Model.businessLogic;
using TestGap.WebApi.Model.businessEntities;
using System.Web.Script.Serialization;

using System;

namespace TestGap.WebApi.Controllers
{
    public class ArticlesController : ApiController
    {
        // GET: api/articles
        public IHttpActionResult Get()
        {
            dynamic Response = new System.Dynamic.ExpandoObject();
            var json = string.Empty;
            try
            {
                IList<Articles> articles = new ArticlesBL().getArticles();
                if (articles.Count > 0)
                {
                    Response.success = true;
                    Response.articles = new List<Articles>();
                    Response.articles = articles;
                    Response.total_elements = articles.Count;
                }
                else
                {
                    Response.success = false;
                    Response.error_code = HttpStatusCode.NotFound;
                    Response.error_msg = "Records not Found";
                }
                json = new JavaScriptSerializer().Serialize(Response);
                return Ok(json);
            }
            catch (System.Exception ex)
            {
                Response.success = false;
                Response.error_code = HttpStatusCode.InternalServerError;
                Response.error_msg = ex.Message.ToString();
                json = new JavaScriptSerializer().Serialize(Response);
                return Ok(json);
            }
        }

   
        [Route("services/articles/stores/")]
        [HttpGet]
        public IHttpActionResult stores(int id)
        {
            dynamic Response = new System.Dynamic.ExpandoObject();
            var json = string.Empty;
            try
            {
                var r = Request;
                var header = r.Headers;

                IList<Articles> articles = new ArticlesBL().getArticlesByStoreId(id);
                if (articles.Count>0)
                {
                    Response.success = true;
                    Response.articles = new List<Articles>();
                    Response.articles = articles;
                    Response.total_elements = articles.Count;
                }
                else
                {
                    Response.success = false;
                    Response.error_code = HttpStatusCode.NotFound;
                    Response.error_msg = "Records not found";
                }
                json = new JavaScriptSerializer().Serialize(Response);
                return Ok(json);
            }          
            catch (System.Exception ex)
            {
                Response.success = false;
                Response.error_code = HttpStatusCode.InternalServerError;
                Response.error_msg = ex.Message.ToString();
                json = new JavaScriptSerializer().Serialize(Response);
                return Ok(json);
            }
            
        }

        // POST: api/articles
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/articles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/articles/5
        public void Delete(int id)
        {
        }
    }
}
