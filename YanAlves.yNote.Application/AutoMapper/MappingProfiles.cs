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
            CreateMap<CategoriaViewModel, Categoria>();

            CreateMap<Tarefa, TarefaViewModel>()
                .ForMember(p => p.TagIds, dest => dest.MapFrom(x => x.Tags.Select(t => t.TagId).ToList()));


            CreateMap<TarefaViewModel, Tarefa>()
                .ForMember(p => p.Categoria, dest => dest.Ignore())
                .ForMember(p => p.Tags, dest => dest.MapFrom(src => src.Tags));

            CreateMap<Tag, TagViewModel>();
            CreateMap<TagViewModel, Tag>()
                .ForMember(p => p.Tarefas, dest => dest.Ignore());
        }
    }
}
