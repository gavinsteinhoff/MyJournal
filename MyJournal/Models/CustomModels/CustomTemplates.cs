using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MyJournal.Models.CustomModels
{
    public class CustomTemplates
    {
        [Key]
        public int CustomTemplateKey { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string Template { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
