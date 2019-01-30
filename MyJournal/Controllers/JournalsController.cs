using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyJournal.Models.JournalModels;
using MyJournal.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;

namespace MyJournal.Controllers
{
    [Authorize]
    public class JournalsController : Controller
    {
        private readonly JournalContext _context;

        public JournalsController(JournalContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Checks to see if the current user owns a journal.
        /// Doesn't check to see if journal exist
        /// </summary>
        /// <param name="journal">
        /// A journal object from the JournalContext
        /// </param>
        /// <returns>
        /// Returns true if the user owns the journal, false if not
        /// </returns>
        private bool AuthJournal(Journal journal)
        {
            if (journal.JournalUser == User.Identity.Name)
            {
                return true;
            }
            return false;
        }
        //End Custom


        // GET: Journals
        public async Task<IActionResult> Index()
        {  
            //return View(await _context.Journals.ToListAsync());
            return View(await _context.Journals.Where(j => j.JournalUser == User.Identity.Name).ToListAsync());
        }

        // GET: Journals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journals
                .SingleOrDefaultAsync(m => m.JournalID == id);
            if (journal == null)
            {
                return NotFound();
            }
            

            if (!AuthJournal(journal))
            {
                return NotFound();
            }

            return View(journal);
        }

        // GET: Journals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Journals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JournalID,JournalText")] Journal journal)
        {
            if (ModelState.IsValid)
            {
                journal.JournalUser = User.Identity.Name;
                journal.JournalDateTime = DateTime.Now;
                _context.Add(journal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(journal);
        }

        // GET: Journals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var journal = await _context.Journals.SingleOrDefaultAsync(m => m.JournalID == id);
            if (journal == null)
            {
                return NotFound();
            }

            if (!AuthJournal(journal))
            {
                return NotFound();
            }

            return View(journal);
        }

        // POST: Journals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JournalID,JournalText")] Journal journal)
        {
            if (id != journal.JournalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalExists(journal.JournalID))
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
            return View(journal);
        }

        // GET: Journals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journals
                .SingleOrDefaultAsync(m => m.JournalID == id);
            if (journal == null)
            {
                return NotFound();
            }

            if (!AuthJournal(journal))
            {
                return NotFound();
            }

            return View(journal);
        }

        // POST: Journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var journal = await _context.Journals.SingleOrDefaultAsync(m => m.JournalID == id);
            _context.Journals.Remove(journal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JournalExists(int id)
        {
            return _context.Journals.Any(e => e.JournalID == id);
        }
    }
}
