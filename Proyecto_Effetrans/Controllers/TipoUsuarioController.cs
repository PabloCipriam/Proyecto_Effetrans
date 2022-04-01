using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Effetrans.Models;

namespace Proyecto_Effetrans.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuario
        public ActionResult Index()
        {
            using(var db = new BD_EffetransEntities3())
            {
                return View(db.Tipo_Usuario.ToList());
            }  
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipo_Usuario tipUsuario)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    db.Tipo_Usuario.Add(tipUsuario);
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