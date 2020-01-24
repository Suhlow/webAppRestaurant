using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.data.Models;
using App.data.Services;

namespace webAppRestaurants.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RestaurantService _service;


        public HomeController(ILogger<HomeController> logger, RestaurantService service)
        {
            _logger = logger;
            this._service = service;
        }

        public IActionResult Index()
        {
            return View(_service.getBest());
        }

        public IActionResult Details(int? id) { return View(_service.getThisResto(id)); }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
