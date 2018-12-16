using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COREAPP2.Persistence.Identity
{
    public class IdentitySeed
    {
        public static async Task IdentitySeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            //var RoleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            //var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Manager", "Member" };


            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1  
                    roleResult = await roleManager.CreateAsync(new ApplicationRole(roleName));
                }
            }

            var poweruser = new ApplicationUser
            {
                UserName = "johndoe@email.com",// Configuration.GetSection("UserSettings")["UserEmail"],
                Email = "johndoe@email.com"//Configuration.GetSection("UserSettings")["UserEmail"]
            };

            string UserPassword = "#skdlf12W";// Configuration.GetSection("UserSettings")["UserPassword"];
            var _user = await userManager.FindByEmailAsync(poweruser.Email);

            if (_user == null)
            {
                var createPowerUser = await userManager.CreateAsync(poweruser, UserPassword);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}
