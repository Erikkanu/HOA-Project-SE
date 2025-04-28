using System.Diagnostics;
using HOA.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HOADbContext _context;

        public HomeController(ILogger<HomeController> logger, HOADbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Residents);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddResident()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddResident(Resident resident)
        {
            if (ModelState.IsValid)
            {
                _context.Residents.Add(resident);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resident);
        }
    }
}
