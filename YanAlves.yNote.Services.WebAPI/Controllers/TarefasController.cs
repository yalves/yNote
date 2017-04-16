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
    [RoutePrefix("v1/Tarefas")]
    public class TarefasController : ApiController
    {
        private readonly ITarefaAppService _tarefaAppService;
        public TarefasController(ITarefaAppService tarefaAppService)
        {
            this._tarefaAppService = tarefaAppService;
        }

        [HttpGet]
        [Route("ObterTarefasFiltradas")]
        public HttpResponseMessage ObterTarefasFiltradas(Guid? tagId = null, Guid? categoriaId = null)
        {
            var statusCode = HttpStatusCode.OK;
            var tarefas = Mapper.Map<ICollection<Tarefa>>(this._tarefaAppService.ObterPorTagECategoria(tagId, categoriaId));

            return Request.CreateResponse(statusCode, tarefas);
        }

        [HttpGet]
        [Route("ObterTarefas")]
        public HttpResponseMessage ObterTarefas()
        {
            var statusCode = HttpStatusCode.OK;
            var tarefas = Mapper.Map<ICollection<Tarefa>>(this._tarefaAppService.ObterTodos());

            return Request.CreateResponse(statusCode, tarefas);
        }
    }
}