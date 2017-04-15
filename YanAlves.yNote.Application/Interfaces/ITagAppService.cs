using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Application.ViewModels;

namespace YanAlves.yNote.Application.Interfaces
{
    public interface ITagAppService : IDisposable
    {
        IEnumerable<TagViewModel> ObterTodos();

        TagViewModel ObterPorId(Guid id);

        TagViewModel Adicionar(TagViewModel Tag);

        TagViewModel Alterar(TagViewModel Tag);

        void Remover(TagViewModel Tag);

        void Remover(Guid id);
    }
}
