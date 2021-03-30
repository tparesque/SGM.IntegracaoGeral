using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SGM.IntegracaoGeral.Api.Controllers
{
	[EnableCors("ApiCorsPolicy")]
    [Route("api/gateway/health-check")]
    [ApiController]
    public class HealthCheckController : Controller
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok();
        }
    }
}
