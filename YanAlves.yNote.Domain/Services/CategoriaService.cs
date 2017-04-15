using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Domain.Entities;
using YanAlves.yNote.Domain.Interfaces.Repositories;
using YanAlves.yNote.Domain.Services.Base;

namespace YanAlves.yNote.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository) : base(categoriaRepository)
        {
            this._categoriaRepository = categoriaRepository;
        }
    }
}
