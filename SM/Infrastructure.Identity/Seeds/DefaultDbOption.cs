using Application.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public class TypeMaster
    {

    }
    public static class DefaultDbOption
    {
        public List<Masters> listTypeMaster = new List<Masters>();
        public static async Task SeedAsync()
        {
            Enum.GetValues(typeof(Masters)).Cast<SomeEnum>();
            //Seed DbOption
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}
