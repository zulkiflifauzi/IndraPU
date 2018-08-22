using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace IndraPU.Component
{
    public static class ExtensionMethod
    {
        public static string GetUserRole(this IPrincipal user)
        {
            if (user.IsInRole("Administrator"))
                return "Administrator";
            else if (user.IsInRole("Anggota"))
                return "Anggota";
            else if (user.IsInRole("Bendahara"))
                return "Bendahara";

            return string.Empty;
        }
    }
}