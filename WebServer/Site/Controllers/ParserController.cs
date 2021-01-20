using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Site.Domain;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    public class ParserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public ParserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost]
        public async Task<IActionResult> ImportPrices([FromBody] PriceDto[] dto)
        {
            return Ok();
        } 
    }
    
}