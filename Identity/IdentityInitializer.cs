using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BCS.MvcWeb.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BCS.MvcWeb.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Rolleri
            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<AplicationRole>(context);
                var manager = new RoleManager<AplicationRole>(store);

                var role = new AplicationRole() {Name = "admin",Description = "admin rolü"};
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<AplicationRole>(context);
                var manager = new RoleManager<AplicationRole>(store);

                var role = new AplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }

            if (!context.Users.Any(i => i.Name == "cansayhan"))
            {
                var store = new UserStore<AplicationUser>(context);
                var manager = new UserManager<AplicationUser>(store);

                var user = new AplicationUser(){Name = "can",Surname = "sayhan",UserName = "cansayhan",Email = "cansayhan@gmail.com",};
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.Name == "gizemsayhan"))
            {
                var store = new UserStore<AplicationUser>(context);
                var manager = new UserManager<AplicationUser>(store);

                var user = new AplicationUser() { Name = "gizem", Surname = "sayhan", UserName = "gizemsayhan", Email = "gizemsayhan@gmail.com", };
                manager.Create(user, "1234567");
               manager.AddToRole(user.Id, "user");
            }

            //User





            base.Seed(context);
        }
    }
}