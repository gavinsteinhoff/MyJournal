using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyJournal.Models.CustomModels
{
    //public class JournalContext : DbContext
    //{
    //    public JournalContext(DbContextOptions<JournalContext> options)
    //        : base(options)
    //    { }

    //    public DbSet<Journal> Journals { get; set; }
    //}

    public class DailyInformation
    {
        public ApiData CreateWatsonReport(IConfiguration _configuration)
        {
            Services.WatsonApi toneApi = new Services.WatsonApi(_configuration["WatsonToneKey"], "https://gateway.watsonplatform.net/tone-analyzer/api", "2017-09-21");
            Services.WatsonApiResponse anaylzedText = toneApi.Anaylze(JournalText);
            ApiData apiData = new ApiData();

            if (!anaylzedText.Error)
            {
                apiData.DocumentTones = new ApiData.DocumentTone();
                apiData.SentenceTones = new List<ApiData.SentenceTone>();

                List<ApiData.Tone> dtTones = new List<ApiData.Tone>();
                foreach (var tone in anaylzedText.DocumentTone.Tones)
                {
                    dtTones.Add(new ApiData.Tone
                    {
                        Score = tone.Score,
                        ToneName = tone.ToneName
                    });
                }
                apiData.DocumentTones.Tones = dtTones;

                foreach (var sentence in anaylzedText.SentencesTone)
                {
                    ApiData.SentenceTone st = new ApiData.SentenceTone();
                    st.Text = sentence.Text;
                    List<ApiData.Tone> stTones = new List<ApiData.Tone>();
                    foreach (var tone in sentence.Tones)
                    {
                        stTones.Add(new ApiData.Tone
                        {
                            Score = tone.Score,
                            ToneName = tone.ToneName
                        });
                    }
                    st.Tones = stTones;
                    apiData.SentenceTones.Add(st);
                }
            }
            apiData.DailyInformation = this;
            return apiData;
        }

        [Key]
        public int DailyInformationID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Journal Entry")]
        public string JournalText { get; set; }

        [DataType(DataType.DateTime)]
        [HiddenInput]
        public DateTime DailyInformationDateTime { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int UserMood { get; set; }

        [HiddenInput]
        public int GeneratedMood { get; set; }

        [HiddenInput]
        public bool GoneThroughWatson { get; set; }

        [Required]
        [Range(0, 1440)]
        [Display(Name = "Minutes Exercising")]
        public int MinExercising { get; set; }

        [Display(Name = "Hours of Sleep")]
        public int HoursSlept { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time you went to bed")]
        public DateTime DownTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time you got out of bed")]
        public DateTime UpTime { get; set; }

        [Required]
        [Range(0, 1440)]
        [Display(Name = "How many minutes did you spend on your phone today?")]
        public int MinPhone { get; set; }

        [Required]
        [Display(Name = "How many good things happened today?")]
        public int NumGoodThings { get; set; }

        [Required]
        [Display(Name = "How many poor things happened today?")]
        public int NumPoorThings { get; set; }

        [Required]
        [Display(Name = "How was your overall day")]
        public int OverallDay { get; set; }

        [Required]
        [Display(Name = "How excited are you for tomorrow?")]
        public int ExcitedForTomorrow { get; set; }

        [Required]
        [Display(Name = "How many minutes did you spend on a hobby")]
        public int MinHobby { get; set; }

        public ApiData ApiData { get; set; }

    }
}
