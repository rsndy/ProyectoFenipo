using System;
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
    public class InscripcionAtletasController : Controller
    {
        private ProyectoFenipoContainer db = new ProyectoFenipoContainer();

        // GET: InscripcionAtletas
        public ActionResult Index()
        {
            var inscripcionAtletasSet = db.InscripcionAtletasSet.Include(i => i.Atleta).Include(i => i.InscripcionEquipo).Include(i => i.Competencia).Include(i => i.CategoriaEdad).Include(i => i.CategoriaPeso);
            return View(inscripcionAtletasSet.ToList());
        }

        // GET: InscripcionAtletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionAtletas inscripcionAtletas = db.InscripcionAtletasSet.Find(id);
            if (inscripcionAtletas == null)
            {
                return HttpNotFound();
            }
            return View(inscripcionAtletas);
        }

        // GET: InscripcionAtletas/Create
        public ActionResult Create()
        {
           
            ViewBag.AtletaId = new SelectList(db.Atletas, "Id", "NombreAtleta");
            ViewBag.InscripcionEquipoId = new SelectList(db.InscripcionEquipos, "Id", "Equipo.NombreEquipo");
            ViewBag.CompetenciaId = new SelectList(db.Competencias, "Id", "Nombre");
            ViewBag.CategoriaEdadId = new SelectList(db.CategoriaEdades, "Id", "NombreCategoriaEdad");
            ViewBag.CategoriaPesoId = new SelectList(db.CategoriaPesos, "Id", "NombreCategoriaPeso");
            return View();
        }

        // POST: InscripcionAtletas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AtletaId,InscripcionEquipoId,CompetenciaId,CategoriaEdadId,CategoriaPesoId")] InscripcionAtletas inscripcionAtletas)
        {
            
            if (ModelState.IsValid)
            {
                db.InscripcionAtletasSet.Add(inscripcionAtletas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtletaId = new SelectList(db.Atletas, "Id", "NombreAtleta", inscripcionAtletas.AtletaId);
            ViewBag.InscripcionEquipoId = new SelectList(db.InscripcionEquipos, "Id", "Equipo.NombreEquipo", inscripcionAtletas.InscripcionEquipoId);
            ViewBag.CompetenciaId = new SelectList(db.Competencias, "Id", "Nombre", inscripcionAtletas.CompetenciaId);
            ViewBag.CategoriaEdadId = new SelectList(db.CategoriaEdades, "Id", "NombreCategoriaEdad", inscripcionAtletas.CategoriaEdadId);
            ViewBag.CategoriaPesoId = new SelectList(db.CategoriaPesos, "Id", "NombreCategoriaPeso", inscripcionAtletas.CategoriaPesoId);
            return View(inscripcionAtletas);
        }

        // GET: InscripcionAtletas/Edit/5
        public ActionResult Edit(int? id)
        {

            var equipoInscrito = db.InscripcionEquipos.GroupJoin(db.Equipos, equi => equi.EquipoId, Ins => Ins.Id,
                (equi, Ins) => new { equi, Ins }).ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionAtletas inscripcionAtletas = db.InscripcionAtletasSet.Find(id);
            if (inscripcionAtletas == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtletaId = new SelectList(db.Atletas, "Id", "NombreAtleta", inscripcionAtletas.AtletaId);
            ViewBag.InscripcionEquipoId = new SelectList(db.InscripcionEquipos, "Id", "equi.Equipo.NombreEquipo", inscripcionAtletas.InscripcionEquipoId);
            ViewBag.CompetenciaId = new SelectList(db.Competencias, "Id", "Nombre", inscripcionAtletas.CompetenciaId);
            ViewBag.CategoriaEdadId = new SelectList(db.CategoriaEdades, "Id", "NombreCategoriaEdad", inscripcionAtletas.CategoriaEdadId);
            ViewBag.CategoriaPesoId = new SelectList(db.CategoriaPesos, "Id", "NombreCategoriaPeso", inscripcionAtletas.CategoriaPesoId);
            return View(inscripcionAtletas);
        }

        // POST: InscripcionAtletas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AtletaId,InscripcionEquipoId,CompetenciaId,CategoriaEdadId,CategoriaPesoId")] InscripcionAtletas inscripcionAtletas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcionAtletas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtletaId = new SelectList(db.Atletas, "Id", "NombreAtleta", inscripcionAtletas.AtletaId);
            ViewBag.InscripcionEquipoId = new SelectList(db.InscripcionEquipos, "Id", "DelegadoEquipo", inscripcionAtletas.InscripcionEquipoId);
            ViewBag.CompetenciaId = new SelectList(db.Competencias, "Id", "Nombre", inscripcionAtletas.CompetenciaId);
            ViewBag.CategoriaEdadId = new SelectList(db.CategoriaEdades, "Id", "NombreCategoriaEdad", inscripcionAtletas.CategoriaEdadId);
            ViewBag.CategoriaPesoId = new SelectList(db.CategoriaPesos, "Id", "NombreCategoriaPeso", inscripcionAtletas.CategoriaPesoId);
            return View(inscripcionAtletas);
        }

        // GET: InscripcionAtletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionAtletas inscripcionAtletas = db.InscripcionAtletasSet.Find(id);
            if (inscripcionAtletas == null)
            {
                return HttpNotFound();
            }
            return View(inscripcionAtletas);
        }

        // POST: InscripcionAtletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InscripcionAtletas inscripcionAtletas = db.InscripcionAtletasSet.Find(id);
            db.InscripcionAtletasSet.Remove(inscripcionAtletas);
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
