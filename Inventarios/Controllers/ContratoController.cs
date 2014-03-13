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
    public class ContratoController : Controller
    {
        private Entities db = new Entities();

        // GET: /Contrato/
        public ActionResult Index()
        {
            var contratos = db.Contratos.Include(c => c.Articulos).Include(c => c.TercerasPersonas).Include(c => c.TipoContrato);
            return View(contratos.ToList());
        }

        // GET: /Contrato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contratos contratos = db.Contratos.Find(id);
            if (contratos == null)
            {
                return HttpNotFound();
            }
            return View(contratos);
        }

        // GET: /Contrato/Create
        public ActionResult Create()
        {
            ViewBag.IdArticulo = new SelectList(db.Articulos, "IdArticulo", "VistaArticulo");
            ViewBag.IdTerceraPersona = new SelectList(db.TercerasPersonas, "IdTerceraPersona", "Nombre");
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "Descripcion");
            return View();
        }

        // POST: /Contrato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdContrato,IdArticulo,IdTerceraPersona,IdTipoContrato,FechaContrato,Detalles")] Contratos contratos)
        {
            if (ModelState.IsValid)
            {
                db.Contratos.Add(contratos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdArticulo = new SelectList(db.Articulos, "IdArticulo", "VistaArticulo", contratos.IdArticulo);
            ViewBag.IdTerceraPersona = new SelectList(db.TercerasPersonas, "IdTerceraPersona", "Nombre", contratos.IdTerceraPersona);
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "Descripcion", contratos.IdTipoContrato);
            return View(contratos);
        }

        // GET: /Contrato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contratos contratos = db.Contratos.Find(id);
            if (contratos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdArticulo = new SelectList(db.Articulos, "IdArticulo", "VistaArticulo", contratos.IdArticulo);
            ViewBag.IdTerceraPersona = new SelectList(db.TercerasPersonas, "IdTerceraPersona", "Nombre", contratos.IdTerceraPersona);
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "Descripcion", contratos.IdTipoContrato);
            return View(contratos);
        }

        // POST: /Contrato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdContrato,IdArticulo,IdTerceraPersona,IdTipoContrato,FechaContrato,Detalles")] Contratos contratos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArticulo = new SelectList(db.Articulos, "IdArticulo", "VistaArticulo", contratos.IdArticulo);
            ViewBag.IdTerceraPersona = new SelectList(db.TercerasPersonas, "IdTerceraPersona", "Nombre", contratos.IdTerceraPersona);
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "Descripcion", contratos.IdTipoContrato);
            return View(contratos);
        }

        // GET: /Contrato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contratos contratos = db.Contratos.Find(id);
            if (contratos == null)
            {
                return HttpNotFound();
            }
            return View(contratos);
        }

        // POST: /Contrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contratos contratos = db.Contratos.Find(id);
            db.Contratos.Remove(contratos);
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
