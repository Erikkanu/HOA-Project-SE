using HOA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HOA.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly HOADbContext dbContext;

        public AnnouncementsController(HOADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View(dbContext.Announcements.ToList());
        }

    }
}