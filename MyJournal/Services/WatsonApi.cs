using IBM.WatsonDeveloperCloud.Util;
using IBM.WatsonDeveloperCloud.ToneAnalyzer.v3;
using IBM.WatsonDeveloperCloud.ToneAnalyzer.v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJournal.Services
{
    public class WatsonApi
    {
        ToneAnalyzerService toneAnalyzer;
        public WatsonApi(string key,string url,string version)
        {
            TokenOptions ReportTokenOptions = new TokenOptions()
            {
                IamApiKey = key,
                ServiceUrl = url
            };
            toneAnalyzer = new ToneAnalyzerService(ReportTokenOptions, version);
        }
        
        public WatsonApiResponse Anaylze(string text)
        {
            ToneInput input = new ToneInput();
            input.Text = text;
            WatsonApiResponse objResponse = new WatsonApiResponse();


            try
            {
                string jsonResponse = toneAnalyzer.Tone(input).ResponseJson;
                objResponse = WatsonApiResponse.FromJson(jsonResponse);
                objResponse.Error = false;
                if (objResponse.SentencesTone == null)
                {
                    objResponse.SentencesTone = new List<SentencesTone>().ToArray();
                }
            }catch
            {
                objResponse.Error = true;
                objResponse.ErrorText = "Counld not get Watson API data. ";
            }

            return objResponse;
        }
    }
}
