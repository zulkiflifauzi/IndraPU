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

            SeedStateCoordinate(context);
        }

        private void SeedStateCoordinate(ApplicationDbContext context)
        {
            var states = context.States.ToList();
            foreach (var state in states)
            {
                switch (state.Title) {
                    case "Prov. D.K.I. Jakarta":
                        state.Latitude = -6.203873;
                        state.Longitude = 106.850223;
                        break;
                    case "Prov. Jawa Barat":
                        state.Latitude = -7.041691;
                        state.Longitude = 107.668602;
                        break;
                    case "Prov. Jawa Tengah":
                        state.Latitude = -7.098884;
                        state.Longitude = 110.140152;
                        break;
                    case "Prov. D.I. Yogyakarta":
                        state.Latitude = -7.847010;
                        state.Longitude = 110.427016;
                        break;
                    case "Prov. Jawa Timur":
                        state.Latitude = -7.540584;
                        state.Longitude = 112.236444;
                        break;
                    case "Prov. Aceh":
                        state.Latitude = 4.702711;
                        state.Longitude = 96.732717;
                        break;
                    case "Prov. Sumatera Utara":
                        state.Latitude = 2.121326;
                        state.Longitude = 99.529939;
                        break;
                    case "Prov. Sumatera Barat":
                        state.Latitude = -0.736092;
                        state.Longitude = 100.806581;
                        break;
                    case "Prov. Riau":
                        state.Latitude = 0.299184;
                        state.Longitude = 101.704556;
                        break;
                    case "Prov. Jambi":
                        state.Latitude = -1.486493;
                        state.Longitude = 102.422073;
                        break;
                    case "Prov. Sumatera Selatan":
                        state.Latitude = -3.312758;
                        state.Longitude = 103.919442;
                        break;
                    case "Prov. Lampung":
                        state.Latitude = -4.559499;
                        state.Longitude = 105.414993;
                        break;
                    case "Prov. Kalimantan Barat":
                        state.Latitude = -0.257943;
                        state.Longitude = 111.497742;
                        break;
                    case "Prov. Kalimantan Tengah":
                        state.Latitude = -1.669472;
                        state.Longitude = 113.373157;
                        break;
                    case "Prov. Kalimantan Selatan":
                        state.Latitude = -3.089291;
                        state.Longitude = 115.280419;
                        break;
                    case "Prov. Kalimantan Timur":
                        state.Latitude = 0.527241;
                        state.Longitude = 116.425679;
                        break;
                    case "Prov. Sulawesi Utara":
                        state.Latitude = 0.640677;
                        state.Longitude = 123.945921;
                        break;
                    case "Prov. Sulawesi Tengah":
                        state.Latitude = -1.429128;
                        state.Longitude = 121.446357;
                        break;
                    case "Prov. Sulawesi Selatan":
                        state.Latitude = -3.644210;
                        state.Longitude = 119.987570;
                        break;
                    case "Prov. Sulawesi Tenggara":
                        state.Latitude = -4.138390;
                        state.Longitude = 122.157577;
                        break;
                    case "Prov. Maluku":
                        state.Latitude = -3.265681;
                        state.Longitude = 130.125156;
                        break;
                    case "Prov. Bali":
                        state.Latitude = -8.406260;
                        state.Longitude = 115.186945;
                        break;
                    case "Prov. Nusa Tenggara Barat":
                        state.Latitude = -8.651466;
                        state.Longitude = 117.358646;
                        break;
                    case "Prov. Nusa Tenggara Timur":
                        state.Latitude = -8.639563;
                        state.Longitude = 121.053700;
                        break;
                    case "Prov. Papua":
                        state.Latitude = -4.284818;
                        state.Longitude = 138.071385;
                        break;
                    case "Prov. Bengkulu":
                        state.Latitude = -3.576029;
                        state.Longitude = 102.354139;
                        break;
                    case "Prov. Maluku Utara":
                        state.Latitude = 1.603253;
                        state.Longitude = 127.811992;
                        break;
                    case "Prov. Banten":
                        state.Latitude = -6.410356;
                        state.Longitude = 106.060902;
                        break;
                    case "Prov. Kepulauan Bangka Belitung":
                        state.Latitude = -2.730136;
                        state.Longitude = 106.434242;
                        break;
                    case "Prov. Gorontalo":
                        state.Latitude = 0.698392;
                        state.Longitude = 122.455734;
                        break;
                    case "Prov. Kepulauan Riau":
                        state.Latitude = 3.945708;
                        state.Longitude = 108.159370;
                        break;
                    case "Prov. Papua Barat":
                        state.Latitude = -1.367545;
                        state.Longitude = 133.151015;
                        break;
                    case "Prov. Sulawesi Barat":
                        state.Latitude = -2.824556;
                        state.Longitude = 119.219580;
                        break;
                    case "Prov. Kalimantan Utara":
                        state.Latitude = 3.041724;
                        state.Longitude = 116.003238;
                        break;
                }
            }

            context.SaveChanges();
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
            string[] rolesToCreate = new string[] { "Data Entry", "Administrator", "Viewer" };
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
