using EC4WebApp.Domains;
using EC4WebApp.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EC4WebApp.Data.Seeders
{
    public static class SeedData
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }

        private static async Task SeedUsers(UserManager<User> userManager)
        {
            var userName = "zawnay160399";
            if(await userManager.FindByNameAsync(userName) is null)
            {
                var email = "zawnaylin@1999";
                var displayName = "Zaw Nay Lin";
                User admin = new()
                {
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    DisplayName = displayName,
                    UserName = userName,
                    NormalizedUserName = userName.ToUpper()
                };

                await userManager.CreateAsync(admin, "Zawnaylin@1999");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                await roleManager.CreateAsync(role);
            }
        }

    }
}
