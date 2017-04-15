using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YanAlves.yNote.Application.Interfaces;
using YanAlves.yNote.Application.ViewModels;

namespace YanAlves.yNote.Presentation.WebMVC.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefaAppService _tarefaAppService;

        public TarefasController(ITarefaAppService TarefaAppService)
        {
            this._tarefaAppService = TarefaAppService;
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
            return View();
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
                _tarefaAppService.Adicionar(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Tarefas/Edit/5
        public ActionResult Edit(Guid id)
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
            TarefaViewModel model = _tarefaAppService.ObterPorId(id);
            _tarefaAppService.Remover(model);
            return RedirectToAction("Index");
        }
    }
}