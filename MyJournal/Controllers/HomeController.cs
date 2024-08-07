﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyJournal.Data;
using MyJournal.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyJournal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "DailyInformations", new { area = "" });
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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

        public async Task<IActionResult> Aggregate(int? daysOld = 30, string curr = "mood")
        {
            ViewBag.curr = curr;
            switch (daysOld)
            {
                case 7:
                    ViewBag.Active7 = "active";
                    break;
                case 30:
                    ViewBag.Active30 = "active";
                    break;
                case 183:
                    ViewBag.Active183 = "active";
                    break;
                case 365:
                    ViewBag.Active365 = "active";
                    break;
            }

            var output = await _context.
                DailyInformations
                .OrderBy(x => x.DailyInformationDateTime)
                .ToListAsync();

            output = output
                .Where(x => (DateTime.Now - x.DailyInformationDateTime).TotalDays <= daysOld)
                .ToList();

            return View(output);
        }
    }
}
