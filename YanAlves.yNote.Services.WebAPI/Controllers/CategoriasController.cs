using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YanAlves.yNote.Application.Interfaces;
using YanAlves.yNote.Domain.Entities;

namespace YanAlves.yNote.Services.WebAPI.Controllers
{
    [RoutePrefix("v1/Categorias")]
    public class CategoriasController : ApiController
    {
        private readonly ICategoriaAppService _categoriaAppService;
        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            this._categoriaAppService = categoriaAppService;
        }

        [HttpGet]
        [Route("ObterCategorias")]
        public HttpResponseMessage ObterCategorias()
        {
            var statusCode = HttpStatusCode.OK;
            var categorias = Mapper.Map<ICollection<Categoria>>(this._categoriaAppService.ObterTodos());

            return Request.CreateResponse(statusCode, categorias);
        }
    }
}