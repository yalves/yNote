using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public override Tarefa ObterPorId(Guid? id)
        {
            var tarefa = _context.Tarefas.Where(x => x.TarefaId == id).FirstOrDefault();

            _context.Entry(tarefa).Collection(t => t.Tags).Load();

            return tarefa;
        }

        public override void Alterar(Tarefa tarefa)
        {
            var tarefaRecuperada = _context.Tarefas.Where(x => x.TarefaId == tarefa.TarefaId).FirstOrDefault();
            _context.Entry(tarefaRecuperada).Collection(t => t.Tags).Load();

            var tagsDeletadas = tarefaRecuperada.Tags.Except(tarefa.Tags).ToList<Tag>();

            var tagsAdicionadas = tarefa.Tags.Except(tarefaRecuperada.Tags).ToList<Tag>();

            tagsDeletadas.ForEach(t => tarefaRecuperada.Tags.Remove(t));

            foreach (Tag tag in tagsAdicionadas)
            {
                if (_context.Entry(tag).State == EntityState.Detached)
                    _context.Tags.Attach(tag);

                tarefaRecuperada.Tags.Add(tag);
            }

            _context.SaveChanges();
        }

        public IEnumerable<Tarefa> ObterPorTagECategoria(Guid tagId, Guid categoriaId)
        {
            return this._context.Tarefas.Where(x => x.Tags.Where(t => t.TagId == tagId).Any() && x.Categoria.CategoriaId == categoriaId);
        }

        public override IEnumerable<Tarefa> ObterTodos()
        {
            var tarefas = this._context.Tarefas;

            foreach (var tarefa in tarefas)
            {
                _context.Entry(tarefa).Collection(t => t.Tags).Load();
            }

            return tarefas;
        }
    }
}