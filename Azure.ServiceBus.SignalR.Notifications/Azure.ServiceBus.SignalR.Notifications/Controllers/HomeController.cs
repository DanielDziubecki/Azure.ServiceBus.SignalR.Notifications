using System.Web.Http;

namespace Azure.ServiceBus.SignalR.Notifications.Controllers
{
    [RoutePrefix("api/service")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("index")]
        public IHttpActionResult Index()
        {
            return Ok();
        }
    }
}
