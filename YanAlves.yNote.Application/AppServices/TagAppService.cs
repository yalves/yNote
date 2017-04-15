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
    public class TagAppService : ITagAppService
    {
        private readonly ITagService _tagService;

        public TagAppService(ITagService TagService)
        {
            this._tagService = TagService;
        }

        public IEnumerable<TagViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TagViewModel>>(this._tagService.ObterTodos());
        }

        public TagViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<TagViewModel>(this._tagService.ObterPorId(id));
        }

        public TagViewModel Adicionar(TagViewModel model)
        {
            var Tag = Mapper.Map<Tag>(model);

            this._tagService.Adicionar(Tag);

            return model;
        }

        public TagViewModel Alterar(TagViewModel model)
        {
            var Tag = Mapper.Map<Tag>(model);

            this._tagService.Alterar(Tag);

            return model;
        }

        public void Remover(Guid id)
        {
            this._tagService.Remover(id);
        }

        public void Remover(TagViewModel model)
        {
            var Tag = Mapper.Map<Tag>(model);
            this._tagService.Remover(Tag);
        }

        public void Dispose()
        {
            this._tagService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
