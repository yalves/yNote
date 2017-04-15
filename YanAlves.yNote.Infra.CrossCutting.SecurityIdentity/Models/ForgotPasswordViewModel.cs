using System.ComponentModel.DataAnnotations;

namespace YanAlves.yNote.Infra.CrossCutting.Security.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
