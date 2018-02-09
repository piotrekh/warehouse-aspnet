using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Warehouse.Api.Controllers
{
    [RoutePrefix("healthcheck")]
    public class HealthCheckController : ApiController
    {
        [HttpGet] 
        [ResponseType(typeof(void))]
        public IHttpActionResult HealthCheck()
        {
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
