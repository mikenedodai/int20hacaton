using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Site.Models;
using Site.Interfaces;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBuckwheat _allBuckwheatItems;

        public HomeController(ILogger<HomeController> logger, IBuckwheat buckwheat)
        {
            _logger = logger;
            _allBuckwheatItems = buckwheat;
        }

        public IActionResult Index()
        {
            var buckwheat = _allBuckwheatItems.BuckwheatItems;
            return View(buckwheat);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }


    }
}