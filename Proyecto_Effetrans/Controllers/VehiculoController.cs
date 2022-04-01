using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Effetrans.Models;

namespace Proyecto_Effetrans.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult Index()
        {
            using(var db = new BD_EffetransEntities3())
            {
                return View(db.Vehiculo.ToList());
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
            using(var db = new BD_EffetransEntities3())
            {
                return PartialView(db.Usuario.ToList());
            }
        }


        public static string NombreMarca(int idMarca)
        {
            using (var db = new BD_EffetransEntities3())
            {
                return db.Marca.Find(idMarca).Nombre;
            }
        }

        public ActionResult ListarMarca()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return PartialView(db.Marca.ToList());
            }
        }



        public static string NombreTipo_Vehiculo(int idTipo_Vehiculo)
        {
            using (var db = new BD_EffetransEntities3())
            {
                return db.Tipo_Vehiculo.Find(idTipo_Vehiculo).Nombre;
            }
        }

        public ActionResult ListarTipo_Vehiculo()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return PartialView(db.Tipo_Vehiculo.ToList());
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    db.Vehiculo.Add(vehiculo);
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
                var findVeh = db.Vehiculo.Find(id);
                return View(findVeh);
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    var findVeh = db.Vehiculo.Find(id);
                    db.Vehiculo.Remove(findVeh);
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
                    Vehiculo findVeh = db.Vehiculo.Where(a => a.IdVehiculo == id).FirstOrDefault();
                    return View(findVeh);
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
        public ActionResult Edit(Vehiculo editVeh)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    Vehiculo veh = db.Vehiculo.Find(editVeh.IdVehiculo);

                    veh.IdUsuario = editVeh.IdUsuario;
                    veh.IdMarca = editVeh.IdMarca;
                    veh.IdTipo_Vehiculo = editVeh.IdTipo_Vehiculo;
                    veh.Placa = editVeh.Placa;
                    veh.Modelo = editVeh.Modelo;
                    veh.Licensia = editVeh.Licensia;
                    veh.Estado = editVeh.Estado;


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