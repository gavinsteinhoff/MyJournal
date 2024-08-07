using System.ComponentModel.DataAnnotations;

namespace MyJournal.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
