using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YanAlves.yNote.Application.Interfaces;

namespace YanAlves.yNote.Services.WebAPI.Controllers
{
    [Route("v1/Tarefas")]
    public class TarefasController : Controller
    {
        private readonly ITarefaAppService _tarefaAppService;
        public TarefasController(ITarefaAppService tarefaAppService)
        {
            this._tarefaAppService = tarefaAppService;
        }

        // GET: Tarefas
        [Route("ObterTarefas")]
        public ActionResult ObterTarefas(Guid tagId, Guid categoriaId)
        {
            return View();
        }
    }
}