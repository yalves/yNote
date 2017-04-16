using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Application.ViewModels;
using YanAlves.yNote.Domain.Entities;

namespace YanAlves.yNote.Application.Interfaces
{
    public interface ITarefaAppService : IDisposable
    {
        IEnumerable<TarefaViewModel> ObterTodos();

        TarefaViewModel ObterPorId(Guid id);

        TarefaViewModel Adicionar(TarefaViewModel Tarefa);

        TarefaViewModel Alterar(TarefaViewModel Tarefa);

        void Remover(TarefaViewModel Tarefa);

        void Remover(Guid id);
    }
}
