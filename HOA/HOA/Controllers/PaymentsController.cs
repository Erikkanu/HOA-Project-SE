using HOA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HOA.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly HOADbContext dbContext;

        public PaymentsController(HOADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View(dbContext.Payments.ToList());
        }
    }
}
