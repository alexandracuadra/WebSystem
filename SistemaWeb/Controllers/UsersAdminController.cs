using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SistemaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersAdminController : Controller
    {
        private static ApplicationDbContext Context = new ApplicationDbContext();
        

      
        public UsersAdminController()
        {
      
        
        }
      
       

        // GET: UsersAdmin
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            return View(Context.Users); //Lista los usuarios registrados
        }
        [HttpPost]
        public async Task<ActionResult> Edit(RegisterViewModel model)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };

                var result = await UserManager.AddPasswordAsync(user.Id,model.Password);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return PartialView();
                }
                return RedirectToAction("Index");
            }
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
            
            ApplicationUser u = UserManager.FindById(Id);
            RegisterViewModel R = new RegisterViewModel {
                UserName = u.UserName,
                Email = u.Email,
                Password = string.Empty
           
            };


            return PartialView(R);
        }

        // GET: UsersAdmin/Details/5
        public ActionResult Details(string Id)
        {
            var thisuser = Context.Users.Where(r => r.Id.Equals(Id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return PartialView(thisuser);
        }

        // GET: UsersAdmin/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: UsersAdmin/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel usuario, FormCollection collection)
        {
           
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
            if (ModelState.IsValid)
            {
               
                var user = new ApplicationUser { UserName = usuario.UserName, Email = usuario.Email };

                var result = await UserManager.CreateAsync(user, usuario.Password);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("",result.Errors.First());
                    return PartialView();
                }
                return RedirectToAction("Index");
            }
            return PartialView(usuario);
        }


        // GET: UsersAdmin/Delete/5
        public ActionResult Delete(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var thisUser = Context.Users.Where(r => r.Id.Equals(Id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            if (thisUser == null)
            {
                return HttpNotFound();
            }
            return PartialView(thisUser);
        }
        // POST: AspNetRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string Id)
        {
            var thisUser = Context.Users.Where(x => x.Id.Equals(Id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Context.Users.Remove(thisUser);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
