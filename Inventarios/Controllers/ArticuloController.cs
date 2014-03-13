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
    public class ArticuloController : Controller
    {
        private Entities db = new Entities();

        // GET: /Articulo/
        public ActionResult Index()
        {
            var articulos = db.Articulos.Include(a => a.Localizaciones).Include(a => a.Modelos).Include(a => a.Personals).Include(a => a.TercerasPersonas);
            return View(articulos.ToList());
        }

        // GET: /Articulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // GET: /Articulo/Create
        public ActionResult Create()
        {
            ViewBag.IdLocalizacion = new SelectList(db.Localizaciones, "IdLocalizacion", "Direccion");
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "VistaModelo");
            ViewBag.IdPersonal = new SelectList(db.Personals, "IdPersonal", "Nombre");
            ViewBag.IdProveedor = new SelectList(db.TercerasPersonas, "IdTerceraPersona", "Nombre");
            return View();
        }

        // POST: /Articulo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdArticulo,CodigoStatus,IdLocalizacion,FechaAdquisicion,FechaUltimoMovimiento,OtrosDetalles,IdModelo,IdPersonal,IdProveedor,CostoAdquisicion")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLocalizacion = new SelectList(db.Localizaciones, "IdLocalizacion", "Direccion", articulos.IdLocalizacion);
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "Fabricante", articulos.IdModelo);
            ViewBag.IdPersonal = new SelectList(db.Personals, "IdPersonal", "Nombre", articulos.IdPersonal);
            ViewBag.IdProveedor = new SelectList(db.TercerasPersonas, "IdTerceraPersona", "Nombre", articulos.IdProveedor);
            return View(articulos);
        }

        // GET: /Articulo/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLocalizacion = new SelectList(db.Localizaciones, "IdLocalizacion", "Direccion", articulos.IdLocalizacion);
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "Fabricante", articulos.IdModelo);
            ViewBag.IdPersonal = new SelectList(db.Personals, "IdPersonal", "Nombre", articulos.IdPersonal);
            ViewBag.IdProveedor = new SelectList(db.TercerasPersonas, "IdTerceraPersona", "Nombre", articulos.IdProveedor);
            return View(articulos);
        }

        // POST: /Articulo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdArticulo,CodigoStatus,IdLocalizacion,FechaAdquisicion,FechaUltimoMovimiento,OtrosDetalles,IdModelo,IdPersonal,IdProveedor,CostoAdquisicion")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLocalizacion = new SelectList(db.Localizaciones, "IdLocalizacion", "Direccion", articulos.IdLocalizacion);
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "Fabricante", articulos.IdModelo);
            ViewBag.IdPersonal = new SelectList(db.Personals, "IdPersonal", "Nombre", articulos.IdPersonal);
            ViewBag.IdProveedor = new SelectList(db.TercerasPersonas, "IdTerceraPersona", "Nombre", articulos.IdProveedor);
            return View(articulos);
        }

        // GET: /Articulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // POST: /Articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulos articulos = db.Articulos.Find(id);
            db.Articulos.Remove(articulos);
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
