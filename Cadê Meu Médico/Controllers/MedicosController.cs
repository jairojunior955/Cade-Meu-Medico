using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data.Entity;
namespace CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {
        private CadeMeuMedicoBDEntities1 db =
        new CadeMeuMedicoBDEntities1();
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include("Cidades").Include("Especialidades");
            return View(medicos);
        }
        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,
            "IDEspecialidade",
            "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medicos.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medicos.IDEspecialidade);
            return View(medicos);
        }

        public ActionResult Editar(long id)
        {
            Medicos medicos = db.Medicos.Find(id);
            ViewBag.IDCidades = new SelectList(db.Cidades, "IDCidade", "Nome", medicos.IDCidade);
            ViewBag.IDEspecialidades = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medicos.IDEspecialidade);

            return View(medicos);
        }

        [HttpPost]
        public ActionResult Editar(Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidades = new SelectList(db.Cidades, "IDCidade", "Nome", medicos.IDCidade);
            ViewBag.IDEspecialidades = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medicos.IDEspecialidade);
            return View(medicos);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Medicos medicos = db.Medicos.Find(id);
                db.Medicos.Remove(medicos);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }
    }
}
