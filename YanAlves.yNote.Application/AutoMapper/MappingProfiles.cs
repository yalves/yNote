using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Application.ViewModels;
using YanAlves.yNote.Domain.Entities;

namespace YanAlves.yNote.Application.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<CategoriaViewModel, Categoria>()
                .ForMember(p => p.Usuario, dest => dest.Ignore());

            CreateMap<Tarefa, TarefaViewModel>();
            CreateMap<TarefaViewModel, Tarefa>()
                .ForMember(p => p.Usuario, dest => dest.Ignore())
                .ForMember(p => p.Categoria, dest => dest.Ignore());

            CreateMap<Tag, TagViewModel>();
            CreateMap<TagViewModel, Tag>()
                .ForMember(p => p.Usuario, dest => dest.Ignore());
        }
    }
}
