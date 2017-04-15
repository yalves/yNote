using System.ComponentModel.DataAnnotations;

namespace YanAlves.yNote.Infra.CrossCutting.Security.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}