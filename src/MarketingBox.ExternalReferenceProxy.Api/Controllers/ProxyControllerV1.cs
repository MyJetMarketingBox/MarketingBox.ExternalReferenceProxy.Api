using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MarketingBox.ExternalReferenceProxy.Api.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class ProxyControllerV1 : ControllerBase
    {
        /// <summary>
        /// </summary>
        /// <remarks>
        /// </remarks>
        [HttpGet("{token}")]
        public async Task<ActionResult> GoToBrand(
            [FromRoute, Required] string token)
        {
            return Ok();
        }
    }
}