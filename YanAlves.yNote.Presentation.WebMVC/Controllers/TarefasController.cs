using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YanAlves.yNote.Application.Interfaces;
using YanAlves.yNote.Application.ViewModels;
using YanAlves.yNote.Domain.Entities;

namespace YanAlves.yNote.Presentation.WebMVC.Controllers
{
    [Authorize]
    public class TarefasController : Controller
    {
        private readonly ITarefaAppService _tarefaAppService;
        private readonly ITagAppService _tagAppService;
        private readonly ICategoriaAppService _categoriaAppService;

        public TarefasController(ITarefaAppService TarefaAppService, ITagAppService tagAppService, ICategoriaAppService categoriaAppService)
        {
            this._tarefaAppService = TarefaAppService;
            this._tagAppService = tagAppService;
            this._categoriaAppService = categoriaAppService;
        }

        // GET: Tarefas
        public ActionResult Index()
        {
            return View(_tarefaAppService.ObterTodos());
        }

        // GET: Tarefas/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarefaViewModel model = _tarefaAppService.ObterPorId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Tarefas/Create
        public ActionResult Create()
        {
            ViewBag.TodasAsTags = this._tagAppService.ObterTodos();
            ViewBag.CategoriaId = new SelectList(this._categoriaAppService.ObterTodos(), "CategoriaId", "Titulo");
            TarefaViewModel model = new TarefaViewModel
            {
                UsuarioId = User.Identity.GetUserId(),
                TagIds = new List<Guid>()
            };

            return View(model);
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarefaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.TarefaId = Guid.NewGuid();
                model.DataDeCriacao = DateTime.Today;
                model.Situacao = Domain.Enums.Situacao.ATIVA;
                model.UsuarioId = User.Identity.GetUserId();
                _tarefaAppService.Adicionar(model);
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(this._categoriaAppService.ObterTodos(), "CategoriaId", "Titulo");
            ViewBag.TodasAsTags = this._tagAppService.ObterTodos();
            return View(model);
        }

        // GET: Tarefas/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.TodasAsTags = this._tagAppService.ObterTodos();
            ViewBag.CategoriaId = new SelectList(this._categoriaAppService.ObterTodos(), "CategoriaId", "Titulo");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TarefaViewModel model = _tarefaAppService.ObterPorId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TarefaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _tarefaAppService.Alterar(model);
                return RedirectToAction("Index");
            }
            ViewBag.TodasAsTags = this._tagAppService.ObterTodos();
            ViewBag.CategoriaId = new SelectList(this._categoriaAppService.ObterTodos(), "CategoriaId", "Titulo");
            return View(model);
        }

        // GET: Tarefas/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarefaViewModel model = _tarefaAppService.ObterPorId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _tarefaAppService.Remover(id);
            return RedirectToAction("Index");
        }
    }
}