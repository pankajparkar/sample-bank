using System.Web.Http;

namespace SampleBank.WebAPI.Controllers
{
    [Route("customers")]
    public class CustomerController : ApiController
    {
        [Route(":id")]
        public string Get(int id)
        {
            return "Test "+ id.ToString();
        }
    }
}
