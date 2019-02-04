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
       
    public class DailyInformtion
    {
        [Key]
        public int DailyInformtionID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string JournalText {get;set;}

        [DataType(DataType.DateTime)]
        [HiddenInput]
        public DateTime DailyInformtionDateTime { get; set; }

        [HiddenInput]
        public string DailyInformtionUser { get; set; }

        [Required]
        public int UserMood { get; set; }
    }
}
