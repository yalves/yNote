using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YanAlves.yNote.Domain.Entities
{
    public class Tag
    {
        public Tag()
        {
            this.TagId = Guid.NewGuid();
        }

        public Guid TagId { get; set; }

        public String Titulo { get; set; }

        public Usuario Usuario { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
