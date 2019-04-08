using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyJournal.Models;
using MyJournal.Models.CustomModels;

namespace MyJournal.Data
{
    public class MyJournalContext : DbContext
    {
        public MyJournalContext(DbContextOptions<MyJournalContext> options) : base(options)
        { }

        public DbSet<DailyInformation> DailyInformations { get; set; }
        public DbSet<CustomTemplates> CustomTemplates { get; set; }
        public DbSet<Sharing> Sharings { get; set; }
        public DbSet<ApiData> ApiDatas { get; set; }


    }
}
