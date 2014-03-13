using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventarios.Models;

namespace Inventarios.Controllers
{
    public class TipoArticuloController : Controller
    {
        private Entities db = new Entities();

        // GET: /TipoArticulo/
        public ActionResult Index()
        {
            return View(db.TipoArticulos.ToList());
        }

        // GET: /TipoArticulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoArticulos tipoarticulos = db.TipoArticulos.Find(id);
            if (tipoarticulos == null)
            {
                return HttpNotFound();
            }
            return View(tipoarticulos);
        }

        // GET: /TipoArticulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoArticulo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdTipo,Descripcion")] TipoArticulos tipoarticulos)
        {
            if (ModelState.IsValid)
            {
                db.TipoArticulos.Add(tipoarticulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoarticulos);
        }

        // GET: /TipoArticulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoArticulos tipoarticulos = db.TipoArticulos.Find(id);
            if (tipoarticulos == null)
            {
                return HttpNotFound();
            }
            return View(tipoarticulos);
        }

        // POST: /TipoArticulo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdTipo,Descripcion")] TipoArticulos tipoarticulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoarticulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoarticulos);
        }

        // GET: /TipoArticulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoArticulos tipoarticulos = db.TipoArticulos.Find(id);
            if (tipoarticulos == null)
            {
                return HttpNotFound();
            }
            return View(tipoarticulos);
        }

        // POST: /TipoArticulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoArticulos tipoarticulos = db.TipoArticulos.Find(id);
            db.TipoArticulos.Remove(tipoarticulos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
