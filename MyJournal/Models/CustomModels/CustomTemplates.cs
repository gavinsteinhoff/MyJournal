using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace MyJournal.Models.CustomModels
{
    public class CustomTemplates
    {
        [Key]
        public int CustomTemplateKey { get; set; }
        [HiddenInput]
        public string User { get; set; }
        [Required]
        public string Template { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
