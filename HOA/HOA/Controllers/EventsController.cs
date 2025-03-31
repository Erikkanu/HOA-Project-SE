using HOA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HOA.Controllers
{
    public class EventsController : Controller
    {
        private readonly HOADbContext dbContext;

        public EventsController(HOADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View(dbContext.Events.ToList());
        }
      
    }
}
