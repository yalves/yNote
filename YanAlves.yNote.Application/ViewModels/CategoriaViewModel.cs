using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YanAlves.yNote.Application.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "Preencha o título")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [Display(Name = "Título")]
        public String Titulo { get; set; }

        [MaxLength(256, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
