using System.ComponentModel.DataAnnotations;

namespace YanAlves.yNote.Infra.CrossCutting.Security.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}