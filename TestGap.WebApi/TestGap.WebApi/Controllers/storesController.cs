
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Script.Serialization;
using TestGap.WebApi.Model.businessLogic;
using TestGap.WebApi.Model.businessEntities;
namespace TestGap.WebApi.Controllers
{
    public class StoresController : ApiController
    {
        // GET: services/stores
        public IHttpActionResult Get()
        {
            dynamic Response = new System.Dynamic.ExpandoObject();
            var json = string.Empty;
            try
            {
                IList<Store> stores = new StoresBL().getStores();
                if (stores.Count>0)
                {
                    Response.success = true;
                    Response.store = new List<Store>();
                    Response.stores = stores;
                    Response.total_elements = stores.Count;
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

        // GET: services/stores/id
        public IHttpActionResult Get(int id)
        {
            return Ok("{value:1}");
        }

        // POST: api/Services
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Services/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Services/5
        public void Delete(int id)
        {
        }
    }
}
