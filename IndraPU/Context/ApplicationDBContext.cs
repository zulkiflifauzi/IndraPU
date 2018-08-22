using Microsoft.AspNet.Identity.EntityFramework;
using IndraPU.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IndraPU.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, NetRole, int, NetUserLogin, NetUserRole, NetUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(null);        }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}