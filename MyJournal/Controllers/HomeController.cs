using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyJournal.Data;
using MyJournal.Models;
using MyJournal.Models.CustomModels;

namespace MyJournal.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyJournalContext _context;

        public HomeController(MyJournalContext context)
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

        public async Task<IActionResult> Aggregate()
        {
            List<DailyInformation> pastYear = await _context.DailyInformations.Where(x => x.DailyInformationDateTime.Year == DateTime.Now.Year).ToListAsync();

            if (pastYear.Count >= 5)
            {
                ViewData["hideAlert"] = "hidden";

                ViewData["moodAverage"] = Math.Round(pastYear.Average(x => x.UserMood), 1);
                ViewData["sleepAverage"] = Math.Round(pastYear.Average(x => x.HoursSlept), 1);
                ViewData["exerciseAverage"] = Math.Round(pastYear.Average(x => x.MinExercising), 0);

                ViewData["daysCompleted"] = pastYear.Count();

                ViewData["amountOfGoodDays"] = pastYear.Where(x => x.UserMood > 2).Count();

                List<int> moodByNumbers = new List<int>();
                moodByNumbers.Add(pastYear.Where(x => x.UserMood == 1).Count());
                moodByNumbers.Add(pastYear.Where(x => x.UserMood == 2).Count());
                moodByNumbers.Add(pastYear.Where(x => x.UserMood == 3).Count());
                moodByNumbers.Add(pastYear.Where(x => x.UserMood == 4).Count());
                moodByNumbers.Add(pastYear.Where(x => x.UserMood == 5).Count());


                List<double> MoodData = new List<double>();
                List<double> SleepData = new List<double>();
                List<double> ExerciseData = new List<double>();
                List<string> DateData = new List<string>();
                for (int i = 1; i <= 12; i++)
                {
                    List<DailyInformation> monthData = pastYear.Where(x => x.DailyInformationDateTime.Month == i).ToList();
                    if (monthData.Count == 0)
                    {
                    }
                    else
                    {
                        MoodData.Add(monthData.Average(x => x.UserMood));
                        SleepData.Add(monthData.Average(x => x.HoursSlept));
                        ExerciseData.Add(monthData.Average(x => x.MinExercising));
                        DateData.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));

                    }
                }










                    ViewData["DateDataJSON"] = Newtonsoft.Json.JsonConvert.SerializeObject(DateData);
                    ViewData["MoodDataJSON"] = Newtonsoft.Json.JsonConvert.SerializeObject(MoodData);
                    ViewData["MoodByNumberJSON"] = Newtonsoft.Json.JsonConvert.SerializeObject(moodByNumbers);
                    ViewData["SleepDataJSON"] = Newtonsoft.Json.JsonConvert.SerializeObject(SleepData);
                    ViewData["ExerciseDataJSON"] = Newtonsoft.Json.JsonConvert.SerializeObject(ExerciseData);
                }
            else
            {
                    ViewData["error"] = "You will need more data to generate reports";
                    ViewData["hidden"] = "hidden";
                }

                return View(await _context.DailyInformations.OrderBy(x => x.DailyInformationDateTime).ToListAsync());
            }
        }
    }
