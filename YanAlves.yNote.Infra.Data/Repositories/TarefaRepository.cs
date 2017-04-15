using System;
using System.Collections.Generic;
using System.Linq;
using YanAlves.yNote.Domain.Entities;
using YanAlves.yNote.Domain.Interfaces.Repositories;
using YanAlves.yNote.Infra.Data.Contexts;
using YanAlves.yNote.Infra.Data.Repositories.Base;

namespace YanAlves.yNote.Infra.Data.Repositories
{
    public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
    {
        private readonly yNoteEntitiesDb _context;

        public TarefaRepository(yNoteEntitiesDb context) : base(context)
        {
            this._context = context;
        }
    }
}