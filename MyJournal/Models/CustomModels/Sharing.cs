using System.ComponentModel.DataAnnotations;
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
