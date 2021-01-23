using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Site.Domain;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    public class ParserController : Controller
    {
        private readonly ILogger<ParserController> _logger;
        private readonly ItemsRepository _itemsRepository;
        public ParserController(ILogger<ParserController> logger, ItemsContext itemsContext)
        {
            _logger = logger;
            Console.WriteLine($"Database name = {itemsContext.Database}");
            _itemsRepository = new ItemsRepository(itemsContext);
        }
        
        [HttpGet]
        public IActionResult Lol()
        {
            return Ok("Welcome, Vladyslav");
        }
        
        [HttpPost]
        public async Task<IActionResult> ImportItems([FromBody] ItemDto[] dto)
        {
            Console.WriteLine("Process items");
            if (dto == null)
                return NoContent();
            return Ok(await _itemsRepository.Insert(dto));
        } 
    }
    
}