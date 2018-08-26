using RosterSdoApplication.Data;
using RosterSdoApplication.Models;
using System.Web.Http;


namespace RosterSdoApplication.Controllers
{
    public class ExempleController : ApiController
    {

        DataBanco data = new DataBanco();

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("route/get")]
        public IHttpActionResult getAlocacoes()
        {
            return Ok(data.Get());
        }

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("route/post")]
        public IHttpActionResult postAlocacoes([FromBody] ObjBanco obj)
        {
            return Ok(data.Post(obj));
        }
    }
}
