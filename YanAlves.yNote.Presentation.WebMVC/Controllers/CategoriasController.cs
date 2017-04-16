using Microsoft.AspNet.Identity;
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
    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriasController(ICategoriaAppService CategoriaAppService)
        {
            this._categoriaAppService = CategoriaAppService;
        }

        // GET: Categorias
        public ActionResult Index()
        {
            return View(_categoriaAppService.ObterTodos());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaViewModel model = _categoriaAppService.ObterPorId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            CategoriaViewModel model = new CategoriaViewModel
            {
                UsuarioId = User.Identity.GetUserId()
            };
            return View(model);
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CategoriaId = Guid.NewGuid();
                _categoriaAppService.Adicionar(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaViewModel model = _categoriaAppService.ObterPorId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _categoriaAppService.Alterar(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaViewModel model = _categoriaAppService.ObterPorId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CategoriaViewModel model = _categoriaAppService.ObterPorId(id);
            _categoriaAppService.Remover(model);
            return RedirectToAction("Index");
        }
    }
}