using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SistemaWeb.Contexto;
using SistemaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
<<<<<<< HEAD
   
=======
    [Authorize(Roles = "Admin")]
>>>>>>> 0366b90f880898ebe2dbed61d65db7cc3cb8723b
    public class UserController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        int rol = 9;
        // GET: User
        public ActionResult Index()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Admin";
                    rol = 0;
                }
                else if (isManager())
                {
                    var usuario = User.Identity;
                    ViewBag.Name = usuario.Name;
                    ViewBag.displayMenu = "Manager";
                    rol = 1;

                }
<<<<<<< HEAD
                else if(IsTeacher())
=======
                else
>>>>>>> 0366b90f880898ebe2dbed61d65db7cc3cb8723b
                {
                    var usuario = User.Identity;
                    ViewBag.Name = usuario.Name;
                    ViewBag.displayMenu = "Docente";
                    rol = 2;
                }
            }
            else
            {
                ViewBag.Name = "El usuario no se ha logeado todavia";
            }
            TempData["infoRol"] = rol;
<<<<<<< HEAD
            

=======
>>>>>>> 0366b90f880898ebe2dbed61d65db7cc3cb8723b
            return View();
        }
        public ActionResult Admin()
        {
            ViewBag.profesores = db.profesores.Count();
            ViewBag.aulas = db.aulas.Count();
            return View();
        }
        public ActionResult Manager()
        {
            ViewBag.profesores = db.profesores.Count();
            ViewBag.aulas = db.aulas.Count();
            return View();

        }
<<<<<<< HEAD
        public ActionResult Docente()
        {            
            ViewBag.aulas = db.aulas.Count();
            return View();

        }

=======
>>>>>>> 0366b90f880898ebe2dbed61d65db7cc3cb8723b
        private bool isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usuario = User.Identity;
                ApplicationDbContext contexto = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));

                var roles = userManager.GetRoles(usuario.GetUserId());

                if (roles[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private bool isManager()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usuario = User.Identity;
                ApplicationDbContext contexto = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));

                var roles = userManager.GetRoles(usuario.GetUserId());

                if (roles[0].ToString() == "Manager")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }

<<<<<<< HEAD
       private bool IsTeacher()
        {
            if (User.Identity.IsAuthenticated)
            {
                var Usuario = User.Identity;
                ApplicationDbContext contexto = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));

                var roles = userManager.GetRoles(Usuario.GetUserId());

                if (roles[0].ToString() == "Docente")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        } 
=======
        
>>>>>>> 0366b90f880898ebe2dbed61d65db7cc3cb8723b
   
    }
}