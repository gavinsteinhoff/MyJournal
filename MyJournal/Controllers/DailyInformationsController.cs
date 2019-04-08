using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyJournal.Data;
using MyJournal.Models.CustomModels;

namespace MyJournal.Controllers
{
    [Authorize]
    public class DailyInformationsController : Controller
    {
        private readonly MyJournalContext _context;
        private readonly IConfiguration _configuration;
        public DailyInformationsController(MyJournalContext context, IConfiguration configuration)
        {
            _context = context;
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
            if (dailyInformation.User == User.Identity.Name)
            {
                return true;
            }
            return false;
        }
        //End Custom

        public IActionResult test()
        {
            //var dailyInformtion =  _context.DailyInformations.SingleOrDefault(m => m.DailyInformationID == 1262);

            string errorText = string.Empty;

            errorText = dailyInformtion.ApiData.ApiDataID.ToString();
            //Watson API
            WatsonToneApi.WatsonToneApi toneApi = new WatsonToneApi.WatsonToneApi(_configuration["WatsonToneKey"], "https://gateway.watsonplatform.net/tone-analyzer/api", "2017-09-21");
            var anaylzedText = toneApi.Anaylze(dailyInformtion.JournalText);
            if (!anaylzedText.Error)
            {
                ApiData apiData = new ApiData();

                dailyInformtion.ApiData = apiData;
                _context.SaveChanges();
            }
            else
            {
                errorText = anaylzedText.ErrorString + "Form still submited.";
            }
            //End Watson API

            return RedirectToAction("Index", new { error = errorText });
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
            return View(await _context.DailyInformations.Where(x => (DateTime.Now - x.DailyInformationDateTime).TotalDays <= daysOld && x.User == User.Identity.Name).ToListAsync());
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

            if (dailyInformtion == null || !AuthorizeData(dailyInformtion))
            {
                return NotFound();
            }

            return View(dailyInformtion);
        }

        // GET: DailyInformtions/Create
        public IActionResult Create()
        {
            ViewData["CustomTemplates"] = Newtonsoft.Json.JsonConvert.SerializeObject(_context.CustomTemplates.Where(x => x.User == User.Identity.Name).ToList());
            return View();
        }

        // POST: DailyInformtions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailyInformationID,Title,JournalText,DailyInformationDateTime,User,UserMood,GeneratedMood,MinExercising,DownTime, UpTime, MinPhone, MinHobby, NumGoodThings, NumPoorThings, OverallDay, ExcitedForTomorrow")] DailyInformation dailyInformtion)
        {
            if (ModelState.IsValid)
            {
                string errorText = string.Empty;
                //Watson API
                WatsonToneApi.WatsonToneApi toneApi = new WatsonToneApi.WatsonToneApi(_configuration["WatsonToneKey"], "https://gateway.watsonplatform.net/tone-analyzer/api", "2017-09-21");
                var anaylzedText = toneApi.Anaylze(dailyInformtion.JournalText);
                if (!anaylzedText.Error)
                {

                }
                else
                {
                    errorText = anaylzedText.ErrorString + "Form still submited.";
                }
                //End Watson API

                dailyInformtion.User = User.Identity.Name;
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

            var dailyInformtion = await _context.DailyInformations.SingleOrDefaultAsync(m => m.DailyInformationID == id);

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
