using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyJournal.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [InverseProperty("Giver")]
        public ICollection<CustomModels.Sharing> Giver { get; set; }
        [InverseProperty("Getter")]
        public ICollection<CustomModels.Sharing> Getter { get; set; }
    }
}
