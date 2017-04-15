using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Domain.Enums;

namespace YanAlves.yNote.Domain.Entities
{
    public class Tarefa
    {
        public Tarefa()
        {
            this.TarefaId = Guid.NewGuid();
        }

        public Guid TarefaId { get; set; }

        public String Titulo { get; set; }

        public String Conteudo { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime Prazo { get; set; }

        public Situacao Situacao { get; set; }

        public virtual Usuario Usuario { get; set; }

        public Guid UsuarioId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public Guid CategoriaId { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
