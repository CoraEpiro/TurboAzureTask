using Microsoft.AspNetCore.Mvc;
using TurboAzureTask.Context;
using TurboAzureTask.Models;

namespace TurboAzureTask.Controllers
{
    public class OneCarController : Controller
    {
        private readonly CarDbContext _context;
        private Car _car;

        public OneCarController(CarDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string id)
        {
            _car = _context.Car.FirstOrDefault(x => x.Id == id);
            return View(_car);
        }
    }
}