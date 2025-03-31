using HOA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HOA.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly HOADbContext dbContext;

        public MaintenanceController(HOADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View(dbContext.Maintenance.ToList());
        }
    }
}
