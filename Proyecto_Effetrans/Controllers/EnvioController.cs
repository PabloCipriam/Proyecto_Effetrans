using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Effetrans.Models;

namespace Proyecto_Effetrans.Controllers
{
    public class EnvioController : Controller
    {
        // GET: Envio
        public ActionResult Index()
        {
            using(var db = new BD_EffetransEntities3())
            {
                return View(db.Envio.ToList());
            }
        }


        public static string NombreUsuario(int idUsuario)
        {
            using (var db = new BD_EffetransEntities3())
            {
                return db.Usuario.Find(idUsuario).Nombre;
            }
        }

        public ActionResult ListarUsuario()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return PartialView(db.Usuario.ToList());
            }
        }


        public static string NombreDepartamento(int idDepartamento)
        {
            using (var db = new BD_EffetransEntities3())
            {
                return db.Departamento.Find(idDepartamento).Nombre;
            }
        }

        public ActionResult ListarDepartamento()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return PartialView(db.Departamento.ToList());
            }
        }



        public static string NombreCiudad(int idCiudad)
        {
            using (var db = new BD_EffetransEntities3())
            {
                return db.Ciudad.Find(idCiudad).Nombre;
            }
        }

        public ActionResult ListarCiudad()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return PartialView(db.Ciudad.ToList());
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Envio envio)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    db.Envio.Add(envio);
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
                var findEnvio = db.Envio.Find(id);
                return View(findEnvio);
            }
        }



        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    var findEnvio = db.Envio.Find(id);
                    db.Envio.Remove(findEnvio);
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
                    Envio findEnvio = db.Envio.Where(a => a.IdEnvio == id).FirstOrDefault();
                    return View(findEnvio);
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
        public ActionResult Edit(Envio editEnvio)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    Envio envio = db.Envio.Find(editEnvio.IdEnvio);

                    envio.IdUsuario = editEnvio.IdUsuario;

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