using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Application.ViewModels;

namespace YanAlves.yNote.Application.Interfaces
{
    public interface ICategoriaAppService : IDisposable
    {
        IEnumerable<CategoriaViewModel> ObterTodos();

        CategoriaViewModel ObterPorId(Guid id);

        CategoriaViewModel Adicionar(CategoriaViewModel Categoria);

        CategoriaViewModel Alterar(CategoriaViewModel Categoria);

        void Remover(CategoriaViewModel Categoria);

        void Remover(Guid id);
    }
}
