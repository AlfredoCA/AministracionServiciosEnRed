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
    public class TipoContratoController : Controller
    {
        private Entities db = new Entities();

        // GET: /TipoContrato/
        public ActionResult Index()
        {
            return View(db.TipoContrato.ToList());
        }

        // GET: /TipoContrato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContrato tipocontrato = db.TipoContrato.Find(id);
            if (tipocontrato == null)
            {
                return HttpNotFound();
            }
            return View(tipocontrato);
        }

        // GET: /TipoContrato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoContrato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdTipoContrato,Descripcion")] TipoContrato tipocontrato)
        {
            if (ModelState.IsValid)
            {
                db.TipoContrato.Add(tipocontrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipocontrato);
        }

        // GET: /TipoContrato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContrato tipocontrato = db.TipoContrato.Find(id);
            if (tipocontrato == null)
            {
                return HttpNotFound();
            }
            return View(tipocontrato);
        }

        // POST: /TipoContrato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdTipoContrato,Descripcion")] TipoContrato tipocontrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipocontrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipocontrato);
        }

        // GET: /TipoContrato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContrato tipocontrato = db.TipoContrato.Find(id);
            if (tipocontrato == null)
            {
                return HttpNotFound();
            }
            return View(tipocontrato);
        }

        // POST: /TipoContrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoContrato tipocontrato = db.TipoContrato.Find(id);
            db.TipoContrato.Remove(tipocontrato);
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
