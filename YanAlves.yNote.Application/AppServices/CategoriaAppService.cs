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
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService(ICategoriaService CategoriaService)
        {
            this._categoriaService = CategoriaService;
        }

        public IEnumerable<CategoriaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CategoriaViewModel>>(this._categoriaService.ObterTodos());
        }

        public CategoriaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<CategoriaViewModel>(this._categoriaService.ObterPorId(id));
        }

        public CategoriaViewModel Adicionar(CategoriaViewModel model)
        {
            var Categoria = Mapper.Map<Categoria>(model);

            this._categoriaService.Adicionar(Categoria);

            return model;
        }

        public CategoriaViewModel Alterar(CategoriaViewModel model)
        {
            var Categoria = Mapper.Map<Categoria>(model);

            this._categoriaService.Alterar(Categoria);

            return model;
        }

        public void Remover(Guid id)
        {
            this._categoriaService.Remover(id);
        }

        public void Remover(CategoriaViewModel model)
        {
            var Categoria = Mapper.Map<Categoria>(model);
            this._categoriaService.Remover(Categoria);
        }

        public void Dispose()
        {
            this._categoriaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
