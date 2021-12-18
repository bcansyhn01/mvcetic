using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BCS.MvcWeb.Identity
{
    public class AplicationRole:IdentityRole
    {
        public string Description { get; set; }
        public AplicationRole()
        {
            
        }
        public AplicationRole(string rolename,string description)
        {
            this.Description = description;
        }
    }
}