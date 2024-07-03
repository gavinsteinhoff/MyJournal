using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyJournal.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [InverseProperty("Giver")]
        public ICollection<CustomModels.Sharing> Giver { get; set; }
        [InverseProperty("Getter")]
        public ICollection<CustomModels.Sharing> Getter { get; set; }
        public bool AllowWatson { get; set; }
    }
}
