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
    public class KnowledgeItemsController : Controller
    {
        private Entities db = new Entities();

        // GET: KnowledgeItems
        public ActionResult Index()
        {
            return View(db.KnowledgeItemSet.ToList());
        }

        // GET: KnowledgeItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgeItem knowledgeItem = db.KnowledgeItemSet.Find(id);
            if (knowledgeItem == null)
            {
                return HttpNotFound();
            }
            return View(knowledgeItem);
        }

        // GET: KnowledgeItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KnowledgeItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,FechaCreacion,FechaUltimaModificacion,Creador,Keywords,Descripcion")] KnowledgeItem knowledgeItem)
        {
            if (ModelState.IsValid)
            {
                db.KnowledgeItemSet.Add(knowledgeItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knowledgeItem);
        }

        // GET: KnowledgeItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgeItem knowledgeItem = db.KnowledgeItemSet.Find(id);
            if (knowledgeItem == null)
            {
                return HttpNotFound();
            }
            return View(knowledgeItem);
        }

        // POST: KnowledgeItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,FechaCreacion,FechaUltimaModificacion,Creador,Keywords,Descripcion")] KnowledgeItem knowledgeItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knowledgeItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knowledgeItem);
        }

        // GET: KnowledgeItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgeItem knowledgeItem = db.KnowledgeItemSet.Find(id);
            if (knowledgeItem == null)
            {
                return HttpNotFound();
            }
            return View(knowledgeItem);
        }

        // POST: KnowledgeItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KnowledgeItem knowledgeItem = db.KnowledgeItemSet.Find(id);
            db.KnowledgeItemSet.Remove(knowledgeItem);
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
