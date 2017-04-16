using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Application.Interfaces;
using YanAlves.yNote.Application.ViewModels;
using YanAlves.yNote.Domain.Entities;
using YanAlves.yNote.Domain.Interfaces.Services;

namespace YanAlves.yNote.Application.AppServices
{
    public class TarefaAppService : ITarefaAppService
    {
        private readonly ITarefaService _tarefaService;
        private readonly ITagService _tagService;

        public TarefaAppService(ITarefaService TarefaService, ITagService tagService)
        {
            this._tarefaService = TarefaService;
            this._tagService = tagService;
        }

        public IEnumerable<TarefaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TarefaViewModel>>(this._tarefaService.ObterTodos());
        }

        public TarefaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<TarefaViewModel>(this._tarefaService.ObterPorId(id));
        }

        public TarefaViewModel Adicionar(TarefaViewModel model)
        {
            var tarefa = Mapper.Map<Tarefa>(model);

            if (model.TagIds != null)
            {
                model.Tags = new List<TagViewModel>();

                foreach (Guid tagId in model.TagIds)
                {
                    tarefa.Tags.Add(this._tagService.ObterPorId(tagId));
                }
            }

            this._tarefaService.Adicionar(tarefa);

            return model;
        }

        public TarefaViewModel Alterar(TarefaViewModel model)
        {
            var Tarefa = Mapper.Map<Tarefa>(model);

            this._tarefaService.Alterar(Tarefa);

            return model;
        }

        public void Remover(Guid id)
        {
            this._tarefaService.Remover(id);
        }

        public void Remover(TarefaViewModel model)
        {
            var Tarefa = Mapper.Map<Tarefa>(model);
            this._tarefaService.Remover(Tarefa);
        }

        public void Dispose()
        {
            this._tarefaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
