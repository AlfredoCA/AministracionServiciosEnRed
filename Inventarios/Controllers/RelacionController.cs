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
    public class RelacionController : Controller
    {
        private Entities db = new Entities();

        // GET: /Relacion/
        public ActionResult Index()
        {
            var relacionset = db.RelacionSet.Include(r => r.Articulos1).Include(r => r.Articulos2);
            return View(relacionset.ToList());
        }

        // GET: /Relacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relacion relacion = db.RelacionSet.Find(id);
            if (relacion == null)
            {
                return HttpNotFound();
            }
            return View(relacion);
        }

        // GET: /Relacion/Create
        public ActionResult Create()
        {
            ViewBag.IdArticulo1 = new SelectList(db.Articulos, "IdArticulo", "VistaArticulo");
            ViewBag.IdArticulo2 = new SelectList(db.Articulos, "IdArticulo", "VistaArticulo");
            return View();
        }

        // POST: /Relacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdArticulo1,IdArticulo2,IdRelacion")] Relacion relacion)
        {
            if (ModelState.IsValid)
            {
                db.RelacionSet.Add(relacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdArticulo1 = new SelectList(db.Articulos, "IdArticulo", "OtrosDetalles", relacion.IdArticulo1);
            ViewBag.IdArticulo2 = new SelectList(db.Articulos, "IdArticulo", "OtrosDetalles", relacion.IdArticulo2);
            return View(relacion);
        }

        // GET: /Relacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relacion relacion = db.RelacionSet.Find(id);
            if (relacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdArticulo1 = new SelectList(db.Articulos, "IdArticulo", "OtrosDetalles", relacion.IdArticulo1);
            ViewBag.IdArticulo2 = new SelectList(db.Articulos, "IdArticulo", "OtrosDetalles", relacion.IdArticulo2);
            return View(relacion);
        }

        // POST: /Relacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdArticulo1,IdArticulo2,IdRelacion")] Relacion relacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArticulo1 = new SelectList(db.Articulos, "IdArticulo", "OtrosDetalles", relacion.IdArticulo1);
            ViewBag.IdArticulo2 = new SelectList(db.Articulos, "IdArticulo", "OtrosDetalles", relacion.IdArticulo2);
            return View(relacion);
        }

        // GET: /Relacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relacion relacion = db.RelacionSet.Find(id);
            if (relacion == null)
            {
                return HttpNotFound();
            }
            return View(relacion);
        }

        // POST: /Relacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Relacion relacion = db.RelacionSet.Find(id);
            db.RelacionSet.Remove(relacion);
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
