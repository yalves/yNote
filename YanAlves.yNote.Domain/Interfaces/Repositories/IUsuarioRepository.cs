using System;
using System.Collections.Generic;
using YanAlves.yNote.Domain.Entities;

namespace YanAlves.yNote.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}