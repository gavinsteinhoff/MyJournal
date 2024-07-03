using System.ComponentModel.DataAnnotations;
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
