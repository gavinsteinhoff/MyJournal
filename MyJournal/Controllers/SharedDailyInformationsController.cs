using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyJournal.Data;
using MyJournal.Models.CustomModels;

namespace MyJournal.Controllers
{
    [Authorize]
    public class SharedDailyInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SharedDailyInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SharedDailyInformations
        public async Task<IActionResult> Index(string giverName)
        {
            var sharings = _context.Sharings
                .Include(m => m.Giver)
                .Include(m => m.Getter)
                .FirstOrDefault(x => x.Giver.Email == giverName);
            if (sharings != null && sharings.Receiver == User.Identity.Name)
            {
                return View(await _context.DailyInformations.Where(x => x.ApplicationUser == sharings.Giver).ToListAsync());
            }
            return View();
        }

        // GET: SharedDailyInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyInformation = await _context.DailyInformations
                .Include(m => m.ApplicationUser)
                .SingleOrDefaultAsync(m => m.DailyInformationID == id);

            var auth = _context.Sharings
                .Include(m => m.Giver)
                .Include(m => m.Getter)
                .FirstOrDefault(x => x.Giver.Email == dailyInformation.ApplicationUser.Email && x.Getter.Email == User.Identity.Name);

            if (dailyInformation == null || auth == null)
            {
                return NotFound();
            }

            return View(dailyInformation);
        }
    }
}
