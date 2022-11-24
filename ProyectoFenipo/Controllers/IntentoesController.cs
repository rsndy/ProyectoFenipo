﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFenipo.Models;

namespace ProyectoFenipo.Controllers
{
    public class IntentoesController : Controller
    {
        private ProyectoFenipoContainer db = new ProyectoFenipoContainer();

        // GET: Intentoes
        public ActionResult Index()
        {
            var intentos = db.Intentos.Include(i => i.InscripcionAtletas);
            return View(intentos.ToList());
        }

        // GET: Intentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intento intento = db.Intentos.Find(id);
            if (intento == null)
            {
                return HttpNotFound();
            }
            return View(intento);
        }

        // GET: Intentoes/Create
        public ActionResult Create()
        {
            ViewBag.InscripcionAtletasId = new SelectList(db.InscripcionAtletasSet, "Id", "Id");
            return View();
        }

        // POST: Intentoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InscripcionAtletasId,Movimiento,NumeroIntento,KilosMovimiento,Estatus")] Intento intento)
        {
            if (ModelState.IsValid)
            {
                db.Intentos.Add(intento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InscripcionAtletasId = new SelectList(db.InscripcionAtletasSet, "Id", "Id", intento.InscripcionAtletasId);
            return View(intento);
        }

        // GET: Intentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intento intento = db.Intentos.Find(id);
            if (intento == null)
            {
                return HttpNotFound();
            }
            ViewBag.InscripcionAtletasId = new SelectList(db.InscripcionAtletasSet, "Id", "Id", intento.InscripcionAtletasId);
            return View(intento);
        }

        // POST: Intentoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InscripcionAtletasId,Movimiento,NumeroIntento,KilosMovimiento,Estatus")] Intento intento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InscripcionAtletasId = new SelectList(db.InscripcionAtletasSet, "Id", "Id", intento.InscripcionAtletasId);
            return View(intento);
        }

        // GET: Intentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intento intento = db.Intentos.Find(id);
            if (intento == null)
            {
                return HttpNotFound();
            }
            return View(intento);
        }

        // POST: Intentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Intento intento = db.Intentos.Find(id);
            db.Intentos.Remove(intento);
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
