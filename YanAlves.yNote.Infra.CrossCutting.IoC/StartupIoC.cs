﻿using YanAlves.yNote.Domain.Interfaces.Repositories;
using YanAlves.yNote.Infra.CrossCutting.Security.Configurations;
using YanAlves.yNote.Infra.CrossCutting.Security.Contexts;
using YanAlves.yNote.Infra.CrossCutting.Security.Models;
using YanAlves.yNote.Infra.Data.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

namespace YanAlves.yNote.Infra.CrossCutting.IoC
{
    public class StartupIoC
    {
        public static void RegisterIoC(Container container)
        {
            // Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);

            // Domain -> Services
            container.Register<IAutorService, AutorService>(Lifestyle.Scoped);
            container.Register<IPostagemService, PostagemService>(Lifestyle.Scoped);
            container.Register<IComentarioService, ComentarioService>(Lifestyle.Scoped);
            container.Register<ITagService, TagService>(Lifestyle.Scoped);

            // Infra.Data -> Repositories
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Scoped);
            container.Register<ITagRepository, TagRepository>(Lifestyle.Scoped);
            container.Register<ITarefaRepository, TarefaRepository>(Lifestyle.Scoped);

            
        }
    }
}