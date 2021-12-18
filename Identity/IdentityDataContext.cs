using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BCS.MvcWeb.Identity
{
    public class IdentityDataContext: IdentityDbContext<AplicationUser>
    {
        public IdentityDataContext() : base("dataConnection")
        {
            
        }
    }
}