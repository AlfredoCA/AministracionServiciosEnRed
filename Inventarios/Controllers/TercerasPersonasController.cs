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
    public class TercerasPersonasController : Controller
    {
        private Entities db = new Entities();

        // GET: /TercerasPersonas/
        public ActionResult Index()
        {
            var terceraspersonas = db.TercerasPersonas.Include(t => t.TipoCompania);
            return View(terceraspersonas.ToList());
        }

        // GET: /TercerasPersonas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TercerasPersonas terceraspersonas = db.TercerasPersonas.Find(id);
            if (terceraspersonas == null)
            {
                return HttpNotFound();
            }
            return View(terceraspersonas);
        }

        // GET: /TercerasPersonas/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoCompania = new SelectList(db.TipoCompania, "IdTipoCompania", "Descripcion");
            return View();
        }

        // POST: /TercerasPersonas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdTerceraPersona,IdTipoCompania,Nombre,Direccion,Rfc,Detalles")] TercerasPersonas terceraspersonas)
        {
            if (ModelState.IsValid)
            {
                db.TercerasPersonas.Add(terceraspersonas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoCompania = new SelectList(db.TipoCompania, "IdTipoCompania", "Descripcion", terceraspersonas.IdTipoCompania);
            return View(terceraspersonas);
        }

        // GET: /TercerasPersonas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TercerasPersonas terceraspersonas = db.TercerasPersonas.Find(id);
            if (terceraspersonas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoCompania = new SelectList(db.TipoCompania, "IdTipoCompania", "Descripcion", terceraspersonas.IdTipoCompania);
            return View(terceraspersonas);
        }

        // POST: /TercerasPersonas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdTerceraPersona,IdTipoCompania,Nombre,Direccion,Rfc,Detalles")] TercerasPersonas terceraspersonas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terceraspersonas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoCompania = new SelectList(db.TipoCompania, "IdTipoCompania", "Descripcion", terceraspersonas.IdTipoCompania);
            return View(terceraspersonas);
        }

        // GET: /TercerasPersonas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TercerasPersonas terceraspersonas = db.TercerasPersonas.Find(id);
            if (terceraspersonas == null)
            {
                return HttpNotFound();
            }
            return View(terceraspersonas);
        }

        // POST: /TercerasPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TercerasPersonas terceraspersonas = db.TercerasPersonas.Find(id);
            db.TercerasPersonas.Remove(terceraspersonas);
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


        public ActionResult SignInAsDifferentUser()
        {

            HttpCookie cookie = base.Request.Cookies["TSWA-Last-User"];

            if (base.User.Identity.IsAuthenticated == false || cookie == null || StringComparer.OrdinalIgnoreCase.Equals(base.User.Identity.Name, cookie.Value))
            {

                string name = string.Empty;
                if (base.Request.IsAuthenticated)
                {
                    name = this.User.Identity.Name;
                }

                cookie = new HttpCookie("TSWA-Last-User", name);
                base.Response.Cookies.Set(cookie);

                base.Response.AppendHeader("Connection", "close");
                base.Response.StatusCode = 0x191;
                base.Response.Clear();
                base.Response.Write("Acceso denegado.");
                base.Response.End();
                return RedirectToAction("Index");
            }

            cookie = new HttpCookie("TSWA-Last-User", string.Empty)
            {
                Expires = DateTime.Now.AddYears(-5)
            };
            base.Response.Cookies.Set(cookie);

            return RedirectToRoute("Default", new { controller = "Home", action = "Index" });
        }


    }
}
