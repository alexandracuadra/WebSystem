using SistemaWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
<<<<<<< HEAD
using SistemaWeb.Contexto;
using System;
using System.Data.Entity;
=======
>>>>>>> 0366b90f880898ebe2dbed61d65db7cc3cb8723b

namespace SistemaWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesAdminController : Controller
    {
<<<<<<< HEAD
        private static ApplicationDbContext Context = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            var roles = Context.Roles;
            return View(roles);
        }


        public ActionResult CreateRol()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRol(IdentityRole roleasp)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Context));//crear rol

                IdentityRole roleASP = new IdentityRole
                {
                    Name = roleasp.Name,
                };
                if (!roleManager.RoleExists(roleASP.Name))//chequea si el rol existe
                {
                    roleManager.Create(roleASP);
                }
                return RedirectToAction("Index");
            }
            return PartialView(roleasp);
        }

        [HttpGet]
        public ActionResult DeleteRol(string Id)
        {

            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var thisRole = Context.Roles.Where(r => r.Id.Equals(Id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            if (thisRole == null)
            {
                return HttpNotFound();
            }
            return PartialView(thisRole);
        }

        // POST: AspNetRoles/Delete/5
        [HttpPost, ActionName("DeleteRol")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string Id)
        {
            IdentityRole thisRole = Context.Roles.Where(x => x.Id.Equals(Id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Context.Roles.Remove(thisRole);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: AspNetRoles/Edit/5
        public ActionResult EditRole(string Id)
        {

            var thisRole = Context.Roles.Where(r => r.Id.Equals(Id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return PartialView(thisRole);
        }


        //Accion para editar roles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRole([Bind(Include = "Id,Name")] IdentityRole role)
        {            
            if (ModelState.IsValid)
            {
                var thisRole = Context.Roles.Where(r => r.Id.Equals(role.Id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                Context.Entry(thisRole).CurrentValues.SetValues(role);
                Context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return PartialView();


        }

        //Pagina creada para la administracion de roles a usuarios
        public ActionResult ManageUserRoles()
        {
            // prepopulat roles for the view dropdown
            var list = Context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>

            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }

        //accion para asignarle un rol a un usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            ApplicationUser user = Context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
            UserManager.AddToRole(user.Id, RoleName);

            ViewBag.ResultMessage = "Rol Asignado Correctamente !";

            // prepopulat roles for the view dropdown
            var list = Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }

        //accion para listar los roles de un usuario determinado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = Context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                

                ViewBag.RolesForThisUser = UserManager.GetRoles(user.Id);

                // prepopulat roles for the view dropdown
                var list = Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }

            return View("ManageUserRoles");
        }


        //Accion para eliminar roles asignados a un usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
            ApplicationUser user = Context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (UserManager.IsInRole(user.Id, RoleName))
            {
                UserManager.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Role Eliminado Correctamente !";
            }
            else
            {
                ViewBag.ResultMessage = "Este usuario no pertenece a este Rol";
            }
            // prepopulat roles for the view dropdown
            var list = Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }

=======
        public RolesAdminController()
        {
        }

        public RolesAdminController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        //
        // GET: /Roles/
        [HttpGet]
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        //
        // GET: /Roles/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            // Get the list of Users in this Role
            var users = new List<ApplicationUser>();

            // Get the list of Users in this Role
            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }

            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            return PartialView(role);
        }

        //
        // GET: /Roles/Create
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(roleViewModel.Name);
                var roleresult = await RoleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return PartialView();
        }

        //
        // GET: /Roles/Edit/Admin
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            RoleViewModel roleModel = new RoleViewModel { Id = role.Id, Name = role.Name };
            return PartialView(roleModel);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = await RoleManager.FindByIdAsync(roleModel.Id);
                role.Name = roleModel.Name;
                await RoleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return PartialView();
        }

        //
        // GET: /Roles/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return PartialView(role);
        }

        //
        // POST: /Roles/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id, string deleteUser)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = await RoleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                IdentityResult result;
                if (deleteUser != null)
                {
                    result = await RoleManager.DeleteAsync(role);
                }
                else
                {
                    result = await RoleManager.DeleteAsync(role);
                }
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return PartialView();
        }
>>>>>>> 0366b90f880898ebe2dbed61d65db7cc3cb8723b
    }
}
