using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Effetrans.Models;

namespace Proyecto_Effetrans.Controllers
{
    public class TipoCargaController : Controller
    {
        // GET: TipoCarga
        public ActionResult Index()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return View(db.Tipo_Carga.ToList());
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipo_Carga tipo_Carga)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    db.Tipo_Carga.Add(tipo_Carga);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }


        public ActionResult Details(int id)
        {
            using (var db = new BD_EffetransEntities3())
            {
                var findTipoCarga = db.Tipo_Carga.Find(id);
                return View(findTipoCarga);
            }
        }


        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    Tipo_Carga findTipoCarga = db.Tipo_Carga.Where(a => a.IdTipo_Carga == id).FirstOrDefault();
                    return View(findTipoCarga);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tipo_Carga editTipoCarga)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    Tipo_Carga tipoCarga = db.Tipo_Carga.Find(editTipoCarga.IdTipo_Carga);

                    tipoCarga.Nombre = editTipoCarga.Nombre;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }


    }
}