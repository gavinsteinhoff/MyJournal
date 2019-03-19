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
    public class SharingsController : Controller
    {
        private readonly MyJournalContext _context;

        public SharingsController(MyJournalContext context)
        {
            _context = context;
        }

        public bool CheckAuth(Sharing sharing)
        {
            if (sharing.Giver == User.Identity.Name)
            {
                return true;
            }
            return false;
        }
        

        // GET: Sharings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sharings.Where(x => x.Receiver == User.Identity.Name).ToListAsync());
        }

        // GET: Sharings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sharing = await _context.Sharings
                .SingleOrDefaultAsync(m => m.SharingKey == id);
            if (sharing == null)
            {
                return NotFound();
            }

            return View(sharing);
        }

        // GET: Sharings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sharings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SharingKey,Giver,Receiver,PermissionLevel")] Sharing sharing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sharing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sharing);
        }

        // GET: Sharings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sharing = await _context.Sharings.SingleOrDefaultAsync(m => m.SharingKey == id);
            if (sharing == null || !CheckAuth(sharing))
            {
                return NotFound();
            }
            return View(sharing);
        }

        // POST: Sharings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SharingKey,Giver,Receiver,PermissionLevel")] Sharing sharing)
        {
            if (id != sharing.SharingKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sharing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SharingExists(sharing.SharingKey))
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
            return View(sharing);
        }

        // GET: Sharings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sharing = await _context.Sharings
                .SingleOrDefaultAsync(m => m.SharingKey == id);
            if (sharing == null || !CheckAuth(sharing))
            {
                return NotFound();
            }

            return View(sharing);
        }

        // POST: Sharings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sharing = await _context.Sharings.SingleOrDefaultAsync(m => m.SharingKey == id);
            _context.Sharings.Remove(sharing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SharingExists(int id)
        {
            return _context.Sharings.Any(e => e.SharingKey == id);
        }
    }
}
