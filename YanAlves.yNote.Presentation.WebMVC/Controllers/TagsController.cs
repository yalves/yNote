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
    public class TagsController : Controller
    {
        private readonly ITagAppService _tagAppService;

        public TagsController(ITagAppService TagAppService)
        {
            this._tagAppService = TagAppService;
        }

        // GET: Tags
        public ActionResult Index()
        {
            return View(_tagAppService.ObterTodos());
        }

        // GET: Tags/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TagViewModel model = _tagAppService.ObterPorId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.TagId = Guid.NewGuid();
                _tagAppService.Adicionar(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TagViewModel model = _tagAppService.ObterPorId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                _tagAppService.Alterar(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Tags/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TagViewModel model = _tagAppService.ObterPorId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TagViewModel model = _tagAppService.ObterPorId(id);
            _tagAppService.Remover(model);
            return RedirectToAction("Index");
        }
    }
}