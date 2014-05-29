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
        public ActionResult Index(string filter = "Pending")
        {
            var ticketSet = db.TicketSet.Include(t => t.KnowledgeItem).Include(t => t.Articulos).Include(t => t.Personals);
            ticketSet = ticketSet.OrderBy(x => x.FechaVencimiento);
            
            if(filter == "Pending")
            {
                ticketSet = ticketSet.Where(x => x.Status != "Problema resuelto");
            }
            else
            {
                ticketSet = ticketSet.Where(x => x.Status == "Problema resuelto");
            }
            
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
            ViewBag.KnowledgeItemId = new SelectList(db.KnowledgeItemSet, "Id", "KnowledgeItemFK");
            ViewBag.ArticulosIdArticulo = new SelectList(db.Articulos, "IdArticulo", "VistaArticulo");
            ViewBag.PersonalsIdPersonal = new SelectList(db.Personals, "IdPersonal", "Nombre");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Categoria,Prioridad,Status,Descripcion,KnowledgeItemId,ArticulosIdArticulo,PersonalsIdPersonal")] Ticket ticket)
        {
            ticket.FechaCreacion = DateTime.Now;
            ticket.FechaUltimaActualizacion = DateTime.Now;
            ticket.IdCreador = User.Identity.Name;
            
            switch(ticket.Prioridad)
            {
                case "Muy alta":
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(2);
                    break;
                case "Alta":
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(8);
                    break;
                case "Media":
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(24);
                    break;
                case "Baja":
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(36);
                    break;
                case "Muy baja":
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(160);
                    break;
                default:                    
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(2400);
                    break;
            }

            if (ModelState.IsValid)
            {
                db.TicketSet.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KnowledgeItemId = new SelectList(db.KnowledgeItemSet, "Id", "KnowledgeItemFK", ticket.KnowledgeItemId);
            ViewBag.ArticulosIdArticulo = new SelectList(db.Articulos, "IdArticulo", "VistaArticulo", ticket.ArticulosIdArticulo);
            ViewBag.PersonalsIdPersonal = new SelectList(db.Personals, "IdPersonal", "Nombre", ticket.PersonalsIdPersonal);
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
            ViewBag.KnowledgeItemId = new SelectList(db.KnowledgeItemSet, "Id", "KnowledgeItemFK", ticket.KnowledgeItemId);
            ViewBag.ArticulosIdArticulo = new SelectList(db.Articulos, "IdArticulo", "VistaArticulo", ticket.ArticulosIdArticulo);
            ViewBag.PersonalsIdPersonal = new SelectList(db.Personals, "IdPersonal", "Nombre", ticket.PersonalsIdPersonal);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Categoria,Prioridad,Status,FechaCreacion,IdCreador,FechaUltimaActualizacion,FechaVencimiento,Descripcion,KnowledgeItemId,ArticulosIdArticulo,PersonalsIdPersonal")] Ticket ticket)
        {
            ticket.FechaUltimaActualizacion = DateTime.Now;
            switch (ticket.Prioridad)
            {
                case "Muy alta":
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(2);
                    break;
                case "Alta":
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(8);
                    break;
                case "Media":
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(24);
                    break;
                case "Baja":
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(36);
                    break;
                case "Muy baja":
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(160);
                    break;
                default:
                    ticket.FechaVencimiento = ticket.FechaCreacion.AddHours(2400);
                    break;
            }
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KnowledgeItemId = new SelectList(db.KnowledgeItemSet, "Id", "KnowledgeItemFK", ticket.KnowledgeItemId);
            ViewBag.ArticulosIdArticulo = new SelectList(db.Articulos, "IdArticulo", "VistaArticulo", ticket.ArticulosIdArticulo);
            ViewBag.PersonalsIdPersonal = new SelectList(db.Personals, "IdPersonal", "Nombre", ticket.PersonalsIdPersonal);
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

        public ActionResult Estadisticas()
        {
            ViewBag.Abiertos = db.TicketSet.Where(x => x.Status != "Problema resuelto").Count();
            ViewBag.Cerrados = db.TicketSet.Where(x => x.Status == "Problema resuelto").Count();

            ViewBag.PeticionServicio = db.TicketSet.Where(x => x.Categoria.StartsWith("Petición")).Count();
            ViewBag.Fallas = db.TicketSet.Where(x => x.Categoria.StartsWith("Fallas")).Count();
            ViewBag.Incidentes = db.TicketSet.Where(x => x.Categoria.StartsWith("Incidentes")).Count();
            ViewBag.Ayuda = db.TicketSet.Where(x => x.Categoria.StartsWith("Ayuda")).Count();

            ViewBag.MuyAlta = db.TicketSet.Where(x => x.Prioridad.Equals("Muy alta")).Count();
            ViewBag.Alta = db.TicketSet.Where(x => x.Prioridad.Equals("Alta")).Count();
            ViewBag.Media = db.TicketSet.Where(x => x.Prioridad.Equals("Media")).Count();
            ViewBag.Baja = db.TicketSet.Where(x => x.Prioridad.Equals("Baja")).Count();
            ViewBag.MuyBaja = db.TicketSet.Where(x => x.Prioridad.Equals("Muy baja")).Count();

            ViewBag.Incidencias = new int[10];
            for (int i = 0; i < 10; i++)
            {
                var inicio = DateTime.Now.Date.AddDays(-i);
                var fin = DateTime.Now.Date.AddDays(-i + 1).AddSeconds(-1);
                ViewBag.Incidencias[i] = db.TicketSet.Where(x => x.FechaCreacion >= inicio && 
                                                                 x.FechaCreacion <  fin).Count();
            }

            return View();
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
