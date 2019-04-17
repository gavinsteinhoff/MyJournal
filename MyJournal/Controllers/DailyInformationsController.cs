using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyJournal.Data;
using MyJournal.Models;
using MyJournal.Models.CustomModels;
using MyJournal.Services;

namespace MyJournal.Controllers
{
    [Authorize]
    public class DailyInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public DailyInformationsController(ApplicationDbContext context, IEmailSender emailSender, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
            _configuration = configuration;
        }

        // Custom Methods

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
        private bool AuthorizeData(DailyInformation dailyInformation)
        {
            if (dailyInformation.ApplicationUser.Email == User.Identity.Name)
            {
                return true;
            }
            return false;
        }
        //End Custom

        public ActionResult testWatson(int? id)
        {
            string errorText = "";

            var dailyInformtion = _context.DailyInformations
                .Include(c => c.ApiData)
                .Include(c => c.ApiData.DocumentTones)
                    .ThenInclude(dt => dt.Tones)
                .Include(c => c.ApiData.SentenceTones)
                    .ThenInclude(st => st.Tones)
                .SingleOrDefault(m => m.DailyInformationID == id);

            foreach (var t in dailyInformtion.ApiData.DocumentTones.Tones)
            {
                errorText += t.ToneName + " " + t.Score;
                errorText += "</br>";
            }

            errorText += "<hr>";
            foreach (var st in dailyInformtion.ApiData.SentenceTones)
            {
                errorText += st.Text + "</br>";
                foreach (var t in st.Tones)
                {
                    errorText += t.ToneName + " " + t.Score;
                    errorText += "</br>";
                }
                errorText += "<hr>";
            }

            return Content(errorText, "text/html");
        }

        public async Task<ActionResult> WatsonAsync(int? id)
        {
            var dailyInformtion = _context.DailyInformations
                .Include(c => c.ApiData)
                .Include(c => c.ApiData.DocumentTones)
                    .ThenInclude(dt => dt.Tones)
                .Include(c => c.ApiData.SentenceTones)
                    .ThenInclude(st => st.Tones)
                .SingleOrDefault(m => m.DailyInformationID == id);

            if (!dailyInformtion.GoneThroughWatson)
            {
                ApiData apiData = dailyInformtion.CreateWatsonReport(_configuration);
                if (apiData != null)
                {
                    dailyInformtion.ApiData = apiData;
                    dailyInformtion.GoneThroughWatson = true;
                    await _context.AddAsync(apiData);
                    await _context.AddAsync(dailyInformtion);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return RedirectToAction("Index", new { error = "Cound't Get Report from Watson Api. You Form was still submited." });
                }
            }

            return View(dailyInformtion.ApiData);
        }



        // GET: DailyInformtions
        public async Task<IActionResult> Index(int? daysOld = 30, string curr = "mood", string error = "")
        {
            ViewBag.curr = curr;
            ViewBag.error = error;
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

            return View(await _context.DailyInformations.Where(x => (DateTime.Now - x.DailyInformationDateTime).TotalDays <= daysOld && x.ApplicationUser.Email == User.Identity.Name).ToListAsync());
        }

        // GET: DailyInformtions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyInformtion = await _context.DailyInformations
                .Include(m => m.ApplicationUser)
                .SingleOrDefaultAsync(m => m.DailyInformationID == id);

            if (dailyInformtion == null || !AuthorizeData(dailyInformtion))
            {
                return NotFound();
            }

            return View(dailyInformtion);
        }

        // GET: DailyInformtions/Create
        public IActionResult Create()
        {
            ViewData["CustomTemplates"] = Newtonsoft.Json.JsonConvert.SerializeObject(_context.CustomTemplates.Where(x => x.ApplicationUser.Email == User.Identity.Name).ToList());
            return View();
        }

        // POST: DailyInformtions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailyInformationID,Title,JournalText,DailyInformationDateTime,User,UserMood,GeneratedMood,MinExercising,DownTime, UpTime, MinPhone, MinHobby, NumGoodThings, NumPoorThings, OverallDay, ExcitedForTomorrow")] DailyInformation dailyInformtion)
        {
            dailyInformtion.HoursSlept = (dailyInformtion.DownTime.Hour - dailyInformtion.UpTime.Hour) / 2;

            if (ModelState.IsValid)
            {
                string errorText = string.Empty;
                ApiData apiData = dailyInformtion.CreateWatsonReport(_configuration);
                if (apiData != null)
                {
                    _context.Add(apiData);
                    dailyInformtion.ApiData = apiData;
                    dailyInformtion.GoneThroughWatson = true;
                }
                else
                {
                    errorText = "Cound't Get Report from Watson Api. You Form was still submited.";
                }

                dailyInformtion.ApplicationUser = await _userManager.GetUserAsync(User);
                dailyInformtion.DailyInformationDateTime = DateTime.Now;
                _context.Add(dailyInformtion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { error = errorText });
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

            var dailyInformtion = await _context.DailyInformations
                .Include(m => m.ApplicationUser)
                .SingleOrDefaultAsync(m => m.DailyInformationID == id);

            if (dailyInformtion == null || !AuthorizeData(dailyInformtion))
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
        public async Task<IActionResult> Edit(int id, [Bind("DailyInformationID,Title,JournalText,DailyInformationDateTime,User,UserMood,GeneratedMood,MinExercising,DownTime, UpTime, MinPhone, MinHobby, NumGoodThings, NumPoorThings, OverallDay, ExcitedForTomorrow")] DailyInformation dailyInformtion)
        {
            dailyInformtion.HoursSlept = (dailyInformtion.DownTime.Hour - dailyInformtion.UpTime.Hour) / 2;

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
                .Include(m => m.ApplicationUser)
                .SingleOrDefaultAsync(m => m.DailyInformationID == id);
            if (dailyInformtion == null || !AuthorizeData(dailyInformtion))
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
            var dailyInformtion = await _context.DailyInformations
                .Include(m => m.ApplicationUser)
                .SingleOrDefaultAsync(m => m.DailyInformationID == id);
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
