﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SistemaWeb.Models;

[assembly: OwinStartupAttribute(typeof(SistemaWeb.Startup))]
namespace SistemaWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CrearUsuariosyRoles();
        }
        public void CrearUsuariosyRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "luis";
                user.Email = "luiscaballero9628@gmail.com";
                string userPWD = "Gachiamr09.10";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Manager"))
            {

                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Alexandra";
                user.Email = "alexandra123@hotmail.com";
                string userPWD = "Gachiamr09.10";
                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Manager");

                }
            }


            // creating Creating Employee role    
            if (!roleManager.RoleExists("Docente"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Docente";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Alejandro";
                user.Email = "alejandro123@hotmail.com";
                string userPWD = "Gachiamr09.10";
                var chkUser = UserManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Docente");

                }

            }

            //Add default User to Role Admin   


        }
    }
}
