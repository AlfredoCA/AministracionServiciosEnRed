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
    public class PersonalController : Controller
    {
        private Entities db = new Entities();

        // GET: /Personal/
        public ActionResult Index()
        {
            var personals = db.Personals.Include(p => p.Departamentos);
            return View(personals.ToList());
        }

        // GET: /Personal/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personals personals = db.Personals.Find(id);
            if (personals == null)
            {
                return HttpNotFound();
            }
            return View(personals);
        }

        // GET: /Personal/Create
        
        public ActionResult Create()
        {
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre");
            return View();
        }

        // POST: /Personal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdPersonal,Nombre,Telefono,Email,Puesto,IdDepartamento")] Personals personals)
        {
            if (ModelState.IsValid)
            {
                db.Personals.Add(personals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", personals.IdDepartamento);
            return View(personals);
        }

        // GET: /Personal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personals personals = db.Personals.Find(id);
            if (personals == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", personals.IdDepartamento);
            return View(personals);
        }

        // POST: /Personal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdPersonal,Nombre,Telefono,Email,Puesto,IdDepartamento")] Personals personals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", personals.IdDepartamento);
            return View(personals);
        }

        // GET: /Personal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personals personals = db.Personals.Find(id);
            if (personals == null)
            {
                return HttpNotFound();
            }
            return View(personals);
        }

        // POST: /Personal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personals personals = db.Personals.Find(id);
            db.Personals.Remove(personals);
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
