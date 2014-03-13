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
    public class TipoCompaniaController : Controller
    {
        private Entities db = new Entities();

        // GET: /TipoCompania/
        public ActionResult Index()
        {
            return View(db.TipoCompania.ToList());
        }

        // GET: /TipoCompania/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCompania tipocompania = db.TipoCompania.Find(id);
            if (tipocompania == null)
            {
                return HttpNotFound();
            }
            return View(tipocompania);
        }

        // GET: /TipoCompania/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoCompania/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdTipoCompania,Descripcion")] TipoCompania tipocompania)
        {
            if (ModelState.IsValid)
            {
                db.TipoCompania.Add(tipocompania);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipocompania);
        }

        // GET: /TipoCompania/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCompania tipocompania = db.TipoCompania.Find(id);
            if (tipocompania == null)
            {
                return HttpNotFound();
            }
            return View(tipocompania);
        }

        // POST: /TipoCompania/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdTipoCompania,Descripcion")] TipoCompania tipocompania)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipocompania).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipocompania);
        }

        // GET: /TipoCompania/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCompania tipocompania = db.TipoCompania.Find(id);
            if (tipocompania == null)
            {
                return HttpNotFound();
            }
            return View(tipocompania);
        }

        // POST: /TipoCompania/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCompania tipocompania = db.TipoCompania.Find(id);
            db.TipoCompania.Remove(tipocompania);
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
