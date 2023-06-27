using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TurboAzureTask.Context;
using TurboAzureTask.Models;
using TurboAzureTask.Services;

namespace TurboAzureTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarDbContext _context;

        public HomeController(ILogger<HomeController> logger, CarDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Seed(string numberOfCars = null!)
        {
            if(numberOfCars is null)
                RedirectToAction("Index");

            int n = int.Parse(numberOfCars!);
            var cars = CarSeed.GenerateCar(n);

            _context.Car.AddRange(cars);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View(_context.Car.ToList());
        }

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