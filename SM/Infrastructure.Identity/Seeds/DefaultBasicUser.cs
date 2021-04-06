using Application.Enums;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "anhptbasic",
                Email = "anhpt103@outlook.com",
                FirstName = "Phạm",
                LastName = "Tuấn Anh",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                UnitCode = (int)UnitCodes.ROOT_UNITCODE
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123!@#Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }

            }
        }
    }
}
