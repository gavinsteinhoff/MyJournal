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
        private readonly MyJournalContext _context;

        public SharedDailyInformationsController(MyJournalContext context)
        {
            _context = context;
        }

        // GET: SharedDailyInformations
        public async Task<IActionResult> Index(string giverName)
        {
            return View(await _context.DailyInformations.Where(x => x.User == giverName).ToListAsync());
        }

        // GET: SharedDailyInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyInformation = await _context.DailyInformations
                .SingleOrDefaultAsync(m => m.DailyInformationID == id);

            var auth = _context.Sharings.FirstOrDefault(x => x.Giver == dailyInformation.User && x.Receiver == User.Identity.Name);
            
            if (dailyInformation == null || auth == null)
            {
                return NotFound();
            }

            return View(dailyInformation);
        }
    }
}
