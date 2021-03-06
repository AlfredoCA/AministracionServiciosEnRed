﻿using System;
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
            ViewBag.IdArticulo1 = new SelectList(db.Articulos, "IdArticulo", "OtrosDetalles");
            ViewBag.IdArticulo2 = new SelectList(db.Articulos, "IdArticulo", "OtrosDetalles");
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
