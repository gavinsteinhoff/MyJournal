using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MyJournal.Models.JournalModels
{
    public class JournalContext : DbContext
    {
        public JournalContext(DbContextOptions<JournalContext> options)
            : base(options)
        { }

        public DbSet<Journal> Journals { get; set; }
    }
       
    public class Journal
    {
        public int JournalID { get; set; }

        [Required]
        public string JournalText {get;set;}

        [DataType(DataType.DateTime)]
        [HiddenInput]
        public DateTime JournalDateTime { get; set; }

        public string JournalUser { get; set; }


    }
}
