using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyJournal.Data;
using MyJournal.Models.CustomModels;

namespace MyJournal.Controllers
{
    public class DailyInformationsController : Controller
    {
        private readonly MyJournalContext _context;

        public DailyInformationsController(MyJournalContext context)
        {
            _context = context;
        }

        // GET: DailyInformtions
        public async Task<IActionResult> Index()
        {
            return View(await _context.DailyInformations.ToListAsync());
        }

        // GET: DailyInformtions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyInformtion = await _context.DailyInformations
                .SingleOrDefaultAsync(m => m.DailyInformationID == id);
            if (dailyInformtion == null)
            {
                return NotFound();
            }

            return View(dailyInformtion);
        }

        // GET: DailyInformtions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DailyInformtions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailyInformtionID,Title,JournalText,DailyInformationDateTime,User,UserMood,GeneratedMood,MinWorkedOut,HoursSlept")] DailyInformation dailyInformtion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyInformtion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dailyInformtion);
        }

        // GET: DailyInformtions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyInformtion = await _context.DailyInformations.SingleOrDefaultAsync(m => m.DailyInformationID == id);
            if (dailyInformtion == null)
            {
                return NotFound();
            }
            return View(dailyInformtion);
        }

        // POST: DailyInformtions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DailyInformtionID,Title,JournalText,DailyInformationDateTime,User,UserMood,GeneratedMood,MinWorkedOut,HoursSlept")] DailyInformation dailyInformtion)
        {
            if (id != dailyInformtion.DailyInformationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyInformtion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyInformtionExists(dailyInformtion.DailyInformationID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dailyInformtion);
        }

        // GET: DailyInformtions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyInformtion = await _context.DailyInformations
                .SingleOrDefaultAsync(m => m.DailyInformationID == id);
            if (dailyInformtion == null)
            {
                return NotFound();
            }

            return View(dailyInformtion);
        }

        // POST: DailyInformtions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyInformtion = await _context.DailyInformations.SingleOrDefaultAsync(m => m.DailyInformationID == id);
            _context.DailyInformations.Remove(dailyInformtion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyInformtionExists(int id)
        {
            return _context.DailyInformations.Any(e => e.DailyInformationID == id);
        }
    }
}
