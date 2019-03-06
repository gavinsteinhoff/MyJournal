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
    public class CustomTemplatesController : Controller
    {
        private readonly MyJournalContext _context;

        public CustomTemplatesController(MyJournalContext context)
        {
            _context = context;
        }

        // GET: CustomTemplates
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomTemplates.ToListAsync());
        }

        // GET: CustomTemplates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customTemplates = await _context.CustomTemplates
                .SingleOrDefaultAsync(m => m.CustomTemplateKey == id);
            if (customTemplates == null)
            {
                return NotFound();
            }

            return View(customTemplates);
        }

        // GET: CustomTemplates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomTemplateKey,User,Template,Name")] CustomTemplates customTemplates)
        {
            customTemplates.User = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _context.Add(customTemplates);
                await _context.SaveChangesAsync();
                return View("~/Views/DailyInformations/Create.cshtml");
            }
            return View(customTemplates);
        }

        // GET: CustomTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customTemplates = await _context.CustomTemplates.SingleOrDefaultAsync(m => m.CustomTemplateKey == id);
            if (customTemplates == null)
            {
                return NotFound();
            }
            return View(customTemplates);
        }

        // POST: CustomTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomTemplateKey,User,Template,Name")] CustomTemplates customTemplates)
        {
            if (id != customTemplates.CustomTemplateKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customTemplates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomTemplatesExists(customTemplates.CustomTemplateKey))
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
            return View(customTemplates);
        }

        // GET: CustomTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customTemplates = await _context.CustomTemplates
                .SingleOrDefaultAsync(m => m.CustomTemplateKey == id);
            if (customTemplates == null)
            {
                return NotFound();
            }

            return View(customTemplates);
        }

        // POST: CustomTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customTemplates = await _context.CustomTemplates.SingleOrDefaultAsync(m => m.CustomTemplateKey == id);
            _context.CustomTemplates.Remove(customTemplates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomTemplatesExists(int id)
        {
            return _context.CustomTemplates.Any(e => e.CustomTemplateKey == id);
        }
    }
}
