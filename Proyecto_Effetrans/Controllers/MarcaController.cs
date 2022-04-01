using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Effetrans.Models;

namespace Proyecto_Effetrans.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return View(db.Marca.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marca marca)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    db.Marca.Add(marca);
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
                var findMarca = db.Marca.Find(id);
                return View(findMarca);
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    var findMarca = db.Marca.Find(id);
                    db.Marca.Remove(findMarca);
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



        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    Marca findMarca = db.Marca.Where(a => a.IdMarca == id).FirstOrDefault();
                    return View(findMarca);
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
        public ActionResult Edit(Marca editMarca)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    Marca marca = db.Marca.Find(editMarca.IdMarca);

                    marca.Nombre = editMarca.Nombre;

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