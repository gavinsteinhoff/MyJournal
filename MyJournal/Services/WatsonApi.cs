using Microsoft.Extensions.Configuration;
using MyJournal.Data;
using System.Collections.Generic;

namespace MyJournal.Services
{
    public class WatsonApi
    {
        //ToneAnalyzerService toneAnalyzer;
        public WatsonApi(string key, string url, string version)
        {
            //TokenOptions ReportTokenOptions = new TokenOptions()
            //{
            //    IamApiKey = key,
            //    ServiceUrl = url
            //};
            //toneAnalyzer = new ToneAnalyzerService(ReportTokenOptions, version);
        }

        public WatsonApiResponse Anaylze(string text)
        {
            ////ToneInput input = new ToneInput();
            //input.Text = text;
            //WatsonApiResponse objResponse = new WatsonApiResponse();


            //try
            //{
            //    string jsonResponse = toneAnalyzer.Tone(input).ResponseJson;
            //    objResponse = WatsonApiResponse.FromJson(jsonResponse);
            //    objResponse.Error = false;
            //    if (objResponse.SentencesTone == null)
            //    {
            //        objResponse.SentencesTone = new List<SentencesTone>().ToArray();
            //    }
            //}
            //catch
            //{
            //    objResponse.Error = true;
            //    objResponse.ErrorText = "Counld not get Watson API data. ";
            //}

            //return objResponse;

            return new WatsonApiResponse();
        }

        public void GenerateAllReports(List<Models.CustomModels.DailyInformation> dailyInformations, ApplicationDbContext _context, IConfiguration _configuration)
        {
            foreach (var daily in dailyInformations)
            {
                if (daily.ApiData == null)
                {
                    if (daily.ApplicationUser.AllowWatson)
                    {
                        Models.CustomModels.ApiData apiData = daily.CreateWatsonReport(_configuration);
                        if (apiData != null)
                        {
                            apiData.DailyInformation = daily;
                            _context.Add(apiData);
                        }
                    }
                }
            }
            _context.SaveChanges();
        }

    }
}
