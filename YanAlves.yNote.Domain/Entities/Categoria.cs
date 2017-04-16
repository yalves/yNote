using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YanAlves.yNote.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            this.CategoriaId = Guid.NewGuid();
        }

        public Guid CategoriaId { get; set; }

        public String Titulo { get; set; }

        public String Descricao { get; set; }

        //public virtual Usuario Usuario { get; set; }

        public String UsuarioId { get; set; }
    }
}
