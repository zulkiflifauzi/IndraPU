using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using IndraPU.Context;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace IndraPU.Models
{
    public class NetUserRole : IdentityUserRole<int> { }

    public class NetUserClaim : IdentityUserClaim<int> { }

    public class NetUserLogin : IdentityUserLogin<int> { }

    public class NetRole : IdentityRole<int, NetUserRole>
    {
        public NetRole() { }

        public NetRole(string name)
        {
            Name = name;
        }
    }

    public class NetUserStore : UserStore<ApplicationUser, NetRole, int, NetUserLogin, NetUserRole, NetUserClaim>
    {
        public NetUserStore(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class NetRoleStore : RoleStore<NetRole, int, NetUserRole>
    {
        public NetRoleStore(ApplicationDbContext context) : base(context)
        {

        }
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, NetUserLogin, NetUserRole, NetUserClaim>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override int Id { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public override string PhoneNumber { get; set; }

        public string CurrentAddress { get; set; }        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}