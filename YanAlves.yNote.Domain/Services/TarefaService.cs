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
    public class TarefaService : ServiceBase<Tarefa>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository) : base(tarefaRepository)
        {
            this._tarefaRepository = tarefaRepository;
        }
    }
}
