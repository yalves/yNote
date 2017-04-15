using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Domain.Interfaces.Repositories.Base;
using YanAlves.yNote.Domain.Interfaces.Services.Base;

namespace YanAlves.yNote.Domain.Services.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this._repository = repository;
        }

        public void Adicionar(TEntity entidade)
        {
            this._repository.Adicionar(entidade);
        }

        public void Alterar(TEntity entidade)
        {
            this._repository.Alterar(entidade);
        }

        public TEntity ObterPorId(Guid id)
        {
            return this._repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return this._repository.ObterTodos();
        }

        public void Remover(TEntity entidade)
        {
            this._repository.Remover(entidade);
        }

        public void Remover(Guid id)
        {
            this._repository.Remover(id);
        }

        public void Dispose()
        {
            this._repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
