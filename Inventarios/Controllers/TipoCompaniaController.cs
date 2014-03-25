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
