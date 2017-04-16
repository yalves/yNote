using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Domain.Interfaces.Repositories.Base;
using YanAlves.yNote.Infra.Data.Contexts;

namespace YanAlves.yNote.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly yNoteEntitiesDb _dbContext;

        public RepositoryBase(yNoteEntitiesDb context)
        {
            this._dbContext = context;
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public virtual TEntity ObterPorId(Guid? id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual void Alterar(TEntity entidade)
        {
            _dbContext.Set<TEntity>().Attach(entidade);
            _dbContext.Entry(entidade).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Remover(TEntity entidade)
        {
            _dbContext.Set<TEntity>().Attach(entidade);
            _dbContext.Set<TEntity>().Remove(entidade);
            _dbContext.SaveChanges();
        }

        public void Remover(Guid id)
        {
            TEntity entity = _dbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }

        public virtual void Adicionar(TEntity entidade)
        {
            _dbContext.Set<TEntity>().Add(entidade);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
