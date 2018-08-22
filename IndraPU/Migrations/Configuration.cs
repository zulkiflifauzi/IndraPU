namespace IndraPU.Migrations
{
    using Context;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            #region Users
            Task.WaitAll(SeedMembershipAsync(context));
            #endregion
        }

        private async Task SeedMembershipAsync(ApplicationDbContext context)
        {
            // create user
            var userManager = new ApplicationUserManager(new NetUserStore(context));
            if (!context.Users.Any(u => u.UserName == "mitnickahead@gmail.com"))
            {
                await userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "mitnickahead@gmail.com",
                    FirstName = "Zulkifli",
                    LastName = "Fauzi",
                    Email = "mitnickahead@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "081339621240"
                },
                    "Password*1"
                );
            }

            // create roles
            string[] rolesToCreate = new string[] { "Data Entry", "Administrator" };
            var roleManager = new ApplicationRoleManager(new NetRoleStore(context));
            foreach (var role in rolesToCreate)
            {
                if (!context.Roles.Any(r => r.Name.Equals(role, StringComparison.InvariantCultureIgnoreCase)))
                {
                    await roleManager.CreateAsync(new NetRole
                    {
                        Name = role
                    }
                    );
                }
            }

            // add user to role
            var adminUser = await userManager.FindByNameAsync("mitnickahead@gmail.com");
            bool isAppAdmin = await userManager.IsInRoleAsync(adminUser.Id, "Administrator");
            if (!isAppAdmin)
            {
                await userManager.AddToRoleAsync(adminUser.Id, "Administrator");
            }
        }
    }
}
