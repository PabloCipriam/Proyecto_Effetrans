using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Effetrans.Models;
using System.Web.Security;
using System.Text;

namespace Proyecto_Effetrans.Controllers
{
    public class UsuarioController : Controller
    {
       [Authorize]
        // GET: Usuario
        public ActionResult Index()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return View(db.Usuario.ToList());
            } 
        }

        

        public static string NombreTipoUsuario(int idTipo_Usuario)
        {
            using (var db = new BD_EffetransEntities3())
            {
                return db.Tipo_Usuario.Find(idTipo_Usuario).Nombre;
            }
        }

        public ActionResult ListarTipoUsuario()
        {
            using (var db = new BD_EffetransEntities3())
            {
                return PartialView(db.Tipo_Usuario.ToList());
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using(var db = new BD_EffetransEntities3())
                {
                    //usuario.Contraseña = UsuarioController.HashSHA1(usuario.Contraseña);
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }


        //public static string HashSHA1(string value)
        //{
        //    var sha1 = System.Security.Cryptography.SHA1.Create();
        //    var inputBytes = Encoding.ASCII.GetBytes(value);
        //    var hash = sha1.ComputeHash(inputBytes);

        //    var sb = new StringBuilder();
        //    for (var i = 0; i < hash.Length; i++)
        //    {
        //        sb.Append(hash[i].ToString("X2"));
        //    }
        //    return sb.ToString();
        //}


        public ActionResult Details(int id)
        {
            using (var db = new BD_EffetransEntities3())
            {
                var findUser = db.Usuario.Find(id);
                return View(findUser);
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    var findUser = db.Usuario.Find(id);
                    db.Usuario.Remove(findUser);
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
                    Usuario findUser = db.Usuario.Where(a => a.IdUsuario == id).FirstOrDefault();
                    return View(findUser);
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
        public ActionResult Edit(Usuario editUser)
        {
            try
            {
                using (var db = new BD_EffetransEntities3())
                {
                    Usuario user = db.Usuario.Find(editUser.IdUsuario);

                    user.Correo = editUser.Correo;
                    user.Contraseña = editUser.Contraseña;
                    user.Tipo_Usuario = editUser.Tipo_Usuario;
                    user.Nombre = editUser.Nombre;
                    user.Apellido = editUser.Apellido;
                    user.Documento = editUser.Documento;
                    user.Direccion = editUser.Direccion;
                    user.Telefono = editUser.Telefono;
                    user.Estado = editUser.Estado;

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


        


        public ActionResult Login(string mensaje = " ")
        {
            ViewBag.Message = mensaje;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string user, string password)
        {
            try
            {
                //string passEncrip = UsuarioController.HashSHA1(password);
                using (var db = new BD_EffetransEntities3())
                {
                    var userLogin = db.Usuario.FirstOrDefault(e => e.Correo == user && e.Contraseña == password);
                    if(userLogin != null)
                    {
                        FormsAuthentication.SetAuthCookie(userLogin.Correo, true);
                        Session["User"] = userLogin;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Login("Verifíque sus datos");
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        [Authorize]
        public ActionResult CloseSession()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}