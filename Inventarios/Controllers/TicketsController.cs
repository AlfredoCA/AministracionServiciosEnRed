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
    public class TicketsController : Controller
    {
        private Entities db = new Entities();

        // GET: Tickets
        public ActionResult Index()
        {
            var ticketSet = db.TicketSet.Include(t => t.KnowledgeItem);
            return View(ticketSet.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.TicketSet.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.KnowledgeItemId = new SelectList(db.KnowledgeItemSet, "Id", "Titulo");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Categoria,Prioridad,FechaCreacion,IdCreador,FechaUltimaActualizacion,FechaVencimiento,Descripcion,KnowledgeItemId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.TicketSet.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KnowledgeItemId = new SelectList(db.KnowledgeItemSet, "Id", "Titulo", ticket.KnowledgeItemId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.TicketSet.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.KnowledgeItemId = new SelectList(db.KnowledgeItemSet, "Id", "Titulo", ticket.KnowledgeItemId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Categoria,Prioridad,FechaCreacion,IdCreador,FechaUltimaActualizacion,FechaVencimiento,Descripcion,KnowledgeItemId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KnowledgeItemId = new SelectList(db.KnowledgeItemSet, "Id", "Titulo", ticket.KnowledgeItemId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.TicketSet.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.TicketSet.Find(id);
            db.TicketSet.Remove(ticket);
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
