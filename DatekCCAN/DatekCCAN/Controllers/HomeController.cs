using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatekCCAN.Data;
using DatekCCAN.Models.SchoolViewModels;

namespace DatekCCAN.Controllers
{
    public class HomeController : Controller
    {
        private readonly WitelContext _context;

        public HomeController(WitelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<EnrollmentDateGroup> data =
                from datek in _context.Dateks
                group datek by datek.TglClosed into dateGroup
                select new EnrollmentDateGroup()
                {
                    TglClosed = dateGroup.Key,
                    DatekCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
