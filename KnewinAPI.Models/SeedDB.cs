using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KnewinAPI.Models
{
    public class SeedDB
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "knewin@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Knewin"
                };
                userManager.CreateAsync(user, "Knewin@2019");
            }
        }
    }
}
