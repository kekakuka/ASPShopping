using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_assignment.Models;
using asp_assignment.Data;
using Microsoft.EntityFrameworkCore;

namespace asp_assignment.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public HomeController(ApplicationDbContext context) {
            this._context = context;
        }

        public async Task<IActionResult> About()
        {
            var applicationDbContext = _context.Souvenirs.Include(s => s.Category).Include(s => s.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}