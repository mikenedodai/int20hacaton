using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Site.Domain;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    public class ParserController : Controller
    {
        private readonly ILogger<ParserController> _logger;
        private readonly IItemsRepository _repository;
        public ParserController(ILogger<ParserController> logger, IItemsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult Lol()
        {
            return Ok("Welcome, Vladyslav");
        }
        
        [HttpPost]
        public async Task<IActionResult> ImportItems()
        {
            
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var itemsDto = JsonConvert.DeserializeObject<ItemsDto>(body);
                if (itemsDto == null)
                    return NoContent();
                var time = DateTime.Now;
                var items = itemsDto.items
                    .Select((item, idx) => ItemConvector.Convert(item, time));
                return Ok(await _repository.Insert(items));
            }
        } 
    }
    
}