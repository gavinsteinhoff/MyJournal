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
        [Display(Name = "Minutes Working Out")]
        public int MinWorkedOut { get; set; }

        [Required]
        [Display(Name ="Hours of Sleep")]
        public int HoursSlept { get; set; }


    }
}
