using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Site.Domain;

namespace Site.Controllers
{
    
    
    [Route("api/[controller]")]
    public class TableController : Controller
    {
        private readonly IItemsRepository _repository;
        
        public TableController(IItemsRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var items = _repository.GetItems();
            var dates = items.Select(i => i.Key.ToString()).ToList();
            var prices = items.Select(i => i.Value.ToString()).ToList();
            var result = new Dictionary<string, List<string>>() {{"dates", dates}, {"prices", prices}};
            return Ok(JsonConvert.SerializeObject(result));
        }
        
    }
}