using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Effetrans.Models;

namespace Proyecto_Effetrans.Controllers
{
    public class CargaController : Controller
    {
        // GET: Carga
        public ActionResult Index()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return View(db.Carga.ToList());
            }
        }

        public static string NombreTipoCarga(int idTipoCarga)
        {
            using (var db = new BD_EffetransEntities3())
            {
                return db.Tipo_Carga.Find(idTipoCarga).Nombre;
            }
        }

        public ActionResult ListarTipoCarga()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return PartialView(db.Tipo_Carga.ToList());
            }
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carga carga)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    db.Carga.Add(carga);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Carga");
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