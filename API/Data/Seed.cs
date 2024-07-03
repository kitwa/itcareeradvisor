using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, 
            RoleManager<AppRole> roleManager, DataContext context)
        {
            if (await userManager.Users.AnyAsync()) return;

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Member"},
                new AppRole{Name = "Admin"},
                new AppRole{Name = "Agent"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        

            var admin = new AppUser
            {
                UserName = "lindaadmin",
                Email = "linda@gmail.com"
            };

            var result = await userManager.CreateAsync(admin, "Linda@2024");

            if(!result.Succeeded) {
                Console.WriteLine(result.Errors);
            } 
            await userManager.AddToRoleAsync(admin, "Admin"); 

            await context.SaveChangesAsync();
        }
    }
}
