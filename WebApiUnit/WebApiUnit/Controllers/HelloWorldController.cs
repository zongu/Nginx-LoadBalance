
namespace WebApiUnit.Controllers
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using WebApiUnit.Applibs;

    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public string Get()
            => $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff")} {Dns.GetHostName()} Port:{ConfigHelper.Port} NO:{ConfigHelper.Number}";
    }
}
