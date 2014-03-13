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
    public class ModelosController : Controller
    {
        private Entities db = new Entities();

        // GET: /Modelos/
        public ActionResult Index()
        {
            var modelos = db.Modelos.Include(m => m.TipoArticulos);
            return View(modelos.ToList());
        }

        // GET: /Modelos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelos modelos = db.Modelos.Find(id);
            if (modelos == null)
            {
                return HttpNotFound();
            }
            return View(modelos);
        }

        // GET: /Modelos/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoArticulo = new SelectList(db.TipoArticulos, "IdTipo", "Descripcion");
            return View();
        }

        // POST: /Modelos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdModelo,Fabricante,Modelo,Especificaciones,IdTipoArticulo")] Modelos modelos)
        {
            if (ModelState.IsValid)
            {
                db.Modelos.Add(modelos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoArticulo = new SelectList(db.TipoArticulos, "IdTipo", "Descripcion", modelos.IdTipoArticulo);
            return View(modelos);
        }

        // GET: /Modelos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelos modelos = db.Modelos.Find(id);
            if (modelos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoArticulo = new SelectList(db.TipoArticulos, "IdTipo", "Descripcion", modelos.IdTipoArticulo);
            return View(modelos);
        }

        // POST: /Modelos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdModelo,Fabricante,Modelo,Especificaciones,IdTipoArticulo")] Modelos modelos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoArticulo = new SelectList(db.TipoArticulos, "IdTipo", "Descripcion", modelos.IdTipoArticulo);
            return View(modelos);
        }

        // GET: /Modelos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelos modelos = db.Modelos.Find(id);
            if (modelos == null)
            {
                return HttpNotFound();
            }
            return View(modelos);
        }

        // POST: /Modelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelos modelos = db.Modelos.Find(id);
            db.Modelos.Remove(modelos);
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
