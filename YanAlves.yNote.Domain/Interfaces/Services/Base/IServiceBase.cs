using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YanAlves.yNote.Domain.Interfaces.Services.Base
{
    public interface IServiceBase<TEntity> : IDisposable
    {
        IEnumerable<TEntity> ObterTodos();

        TEntity ObterPorId(Guid id);

        void Adicionar(TEntity entidade);

        void Alterar(TEntity entidade);

        void Remover(TEntity entidade);

        void Remover(Guid id);
    }
}
