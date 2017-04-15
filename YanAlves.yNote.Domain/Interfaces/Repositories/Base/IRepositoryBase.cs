using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YanAlves.yNote.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> ObterTodos();

        TEntity ObterPorId(Guid? id);

        void Adicionar(TEntity autor);

        void Alterar(TEntity autor);

        void Remover(TEntity autor);

        void Remover(Guid id);

        void Dispose();
    }
}
