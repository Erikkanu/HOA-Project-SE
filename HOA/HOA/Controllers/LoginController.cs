using HOA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HOA.Controllers
{
    public class LoginController : Controller
    {
        private readonly HOADbContext dbContext;

        public LoginController(HOADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View(dbContext.Login.ToList());
        }
    }
}