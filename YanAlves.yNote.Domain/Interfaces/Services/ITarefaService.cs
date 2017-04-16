using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Domain.Entities;
using YanAlves.yNote.Domain.Interfaces.Services.Base;

namespace YanAlves.yNote.Domain.Interfaces.Services
{
    public interface ITarefaService : IServiceBase<Tarefa>
    {
        IEnumerable<Tarefa> ObterPorTagECategoria(Guid? tagId, Guid? categoriaId);
    }
}
