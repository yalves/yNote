﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Domain.Entities;
using YanAlves.yNote.Domain.Enums;

namespace YanAlves.yNote.Application.ViewModels
{
    public class TarefaViewModel
    {
        [Key]
        public Guid TarefaId { get; set; }

        [Required(ErrorMessage = "Preencha o título")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [Display(Name = "Título")]
        public String Titulo { get; set; }

        [Required(ErrorMessage = "Preencha o título")]
        [MaxLength(256, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [Display(Name = "Conteúdo")]
        public String Conteudo { get; set; }

        public Guid UsuarioId { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime Prazo { get; set; }

        public Situacao Situacao { get; set; }

        public Guid CategoriaId { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}