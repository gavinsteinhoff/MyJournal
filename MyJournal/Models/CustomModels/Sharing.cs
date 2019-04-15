using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MyJournal.Models.CustomModels
{
    public class Sharing
    {
        [Key]
        public int SharingID { get; set; }

        public ApplicationUser Giver { get; set; }
        public ApplicationUser Getter { get; set; }

        [Required]
        public string Receiver { get; set; }

        public int PermissionLevel { get; set; }
    }
}
