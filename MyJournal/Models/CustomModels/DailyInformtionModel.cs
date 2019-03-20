using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
        [Key]
        public int DailyInformationID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string JournalText {get;set;}

        [DataType(DataType.DateTime)]
        [HiddenInput]
        public DateTime DailyInformationDateTime { get; set; }

        [HiddenInput]
        public string User { get; set; }

        [Required]
        public int UserMood { get; set; }

        [HiddenInput]
        public int GeneratedMood { get; set; }

        [Required]
        [Display(Name = "Minutes Exercising")]
        public int MinExercising { get; set; }

        [Display(Name ="Hours of Sleep")]
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

    }
}
