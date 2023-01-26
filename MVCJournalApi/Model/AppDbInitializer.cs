using Microsoft.AspNetCore.Identity;
using MVCJournalApi.Areas.Identity.Data;
using System.Data.Entity;

namespace MVCJournalApi.Model
{
    public class AppDbInitializer
    {
        public static async Task Initialize (ApplicationDbContext context, 
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            string adminRole = "Admin";
            string studentRole = "Student";
            string teacherRole = "Teacher";
            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }
            if(await roleManager.FindByNameAsync(studentRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(studentRole));
            }
            if (await roleManager.FindByNameAsync(teacherRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(teacherRole));
            }

        }
    }
}
