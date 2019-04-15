using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyJournal.Data;
using MyJournal.Models;
using MyJournal.Models.CustomModels;
using MyJournal.Services;

namespace MyJournal.Controllers
{
    [Authorize]
    public class SharingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private UserManager<ApplicationUser> _userManager;

        public SharingsController(ApplicationDbContext context, IEmailSender emailSender, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public async Task<bool> CheckAuthAsync(Sharing sharing)
        {
            if (sharing.Giver == await _userManager.GetUserAsync(User))
            {
                return true;
            }
            return false;
        }

        //GET: Sharings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sharings
                .Where(m => m.Giver.Email == User.Identity.Name || m.Getter.Email == User.Identity.Name)
                .Include(m => m.Giver)
                .Include(m => m.Getter)
                .ToListAsync());
        }

        // GET: Sharings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sharing = await _context.Sharings
                .SingleOrDefaultAsync(m => m.SharingID == id);

            bool auth = await CheckAuthAsync(sharing);
            if (sharing == null || !auth)
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
        public async Task<IActionResult> Create([Bind("SharingID,Receiver,PermissionLevel")] Sharing sharing)
        {
            if (ModelState.IsValid)
            {
                sharing.Giver = await _userManager.GetUserAsync(User);
                sharing.Getter = _userManager.Users.FirstOrDefault(u => u.Email == sharing.Receiver);
                
                string link = "<a href='https://mydailyjournal.azurewebsites.net/Sharings'>link</a>";
                string msg = $"{sharing.Giver.Email} has shared their My Journal with you. \nHere is their link: {link}";
                await _emailSender.SendEmailAsync(sharing.Receiver, "Someone shared with you on My Journal", msg);

                link = "<a href='https://mydailyjournal.azurewebsites.net/Manage/SetPassword'>link</a>";
                msg = $@"You have shared your MyJournal with {sharing.Receiver}\nIf this was not you, you can remove it here: {link}\nAlso reset your password here {link}";
                await _emailSender.SendEmailAsync(sharing.Getter.Email, "You Shared with Someone on My Journal", msg);

                _context.Add(sharing);
                await _context.SaveChangesAsync();
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
                .SingleOrDefaultAsync(m => m.SharingID == id);

            bool auth = await CheckAuthAsync(sharing);
            if (sharing == null || !auth)
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
            var sharing = await _context.Sharings.SingleOrDefaultAsync(m => m.SharingID == id);
            _context.Sharings.Remove(sharing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SharingExists(int id)
        {
            return _context.Sharings.Any(e => e.SharingID == id);
        }
    }
}
