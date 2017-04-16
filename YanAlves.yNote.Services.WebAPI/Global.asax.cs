using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using YanAlves.yNote.Application.AppServices;
using YanAlves.yNote.Application.Interfaces;
using YanAlves.yNote.Infra.CrossCutting.Security.Contexts;
using YanAlves.yNote.Infra.CrossCutting.Security.Configurations;
using YanAlves.yNote.Infra.Data.Contexts;
using YanAlves.yNote.Infra.CrossCutting.Security.Models;
using YanAlves.yNote.Domain.Services;
using YanAlves.yNote.Domain.Interfaces.Services;
using YanAlves.yNote.Domain.Interfaces.Repositories;
using YanAlves.yNote.Infra.Data.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using YanAlves.yNote.Application.AutoMapper;

namespace YanAlves.yNote.Services.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfiguration.RegistrarMapeamentos();

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:

            // Identity
            container.Register<yNoteEntitiesDb>(Lifestyle.Scoped);

            // Domain -> Services
            container.Register<ICategoriaService, CategoriaService>(Lifestyle.Scoped);
            container.Register<ITarefaService, TarefaService>(Lifestyle.Scoped);
            container.Register<ITagService, TagService>(Lifestyle.Scoped);

            // Application -> AppServices
            container.Register<ICategoriaAppService, CategoriaAppService>(Lifestyle.Scoped);
            container.Register<ITarefaAppService, TarefaAppService>(Lifestyle.Scoped);
            container.Register<ITagAppService, TagAppService>(Lifestyle.Scoped);

            // Infra.Data -> Repositories
            container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Scoped);
            container.Register<ITagRepository, TagRepository>(Lifestyle.Scoped);
            container.Register<ITarefaRepository, TarefaRepository>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
