using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Effetrans.Models;

namespace Proyecto_Effetrans.Controllers
{
    public class Tipo_VehiculoController : Controller
    {
        // GET: Tipo_Vehiculo
        public ActionResult Index()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return View(db.Tipo_Vehiculo.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipo_Vehiculo tipo_Vehiculo)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    db.Tipo_Vehiculo.Add(tipo_Vehiculo);
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
                var findTipVeh = db.Tipo_Vehiculo.Find(id);
                return View(findTipVeh);
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    var findTipVeh = db.Tipo_Vehiculo.Find(id);
                    db.Tipo_Vehiculo.Remove(findTipVeh);
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