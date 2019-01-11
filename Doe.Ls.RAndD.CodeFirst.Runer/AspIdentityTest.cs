using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Doe.Ls.RAndD.CodeFirst.Runer
{
    public class AspIdentityTest:TestBase
    {
        protected override void RunCore()
        {
            //CreateUserIdentityForSpecificDbConnection();
            //CreateUsersWithClaims();
            AddingPasswords();
        }

        private static void AddingPasswords()
        {
            var identityDbContext = new IdentityDbContext<IdentityUser>("IdentityConnection");
            var userStore = new UserStore<IdentityUser>(identityDbContext);
            var userManager = new UserManager<IdentityUser>(userStore);
            foreach (var user in userManager.Users.ToList())
            {
                var result = userManager.AddPasswordAsync(user.Id, "helloWorld@123").Result;

                Console.WriteLine(result.Succeeded);
                Console.WriteLine(user.PasswordHash);
            }
        }

        private static void CreateUsersWithClaims()
        {
            var identityDbContext = new IdentityDbContext<IdentityUser>("IdentityConnection");
            var userStore = new UserStore<IdentityUser>(identityDbContext);
            var userManager = new UserManager<IdentityUser>(userStore);

            for (int i = 0; i < 100; i++)
            {
                var result = userManager.Create(new IdentityUser()
                {
                    Email = $"refkyw{i}@gmail.com",
                    UserName = $"refky{i}.wahib{1}@gmail.com",
                    PhoneNumber = $"042{i}17{i}197"
                });

                if (result.Succeeded)
                {
                    var user = userManager.FindByEmailAsync($"refkyw{i}@gmail.com").Result;
                    userManager.AddClaim(user.Id,
                        new Claim(ClaimTypes.DateOfBirth, DateTime.Now.AddYears(-20 - (i / 4)).ToString()));
                    userManager.AddClaim(user.Id, new Claim(ClaimTypes.UserData, i.ToString()));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error);
                    }
                }
            }
        }

        private static void CreateUserIdentityForSpecificDbConnection()
        {
            var identityDbContext = new IdentityDbContext<IdentityUser>("IdentityConnection");
            var userStore = new UserStore<IdentityUser>(identityDbContext);
            var userManager = new UserManager<IdentityUser>(userStore);

            var result = userManager.Create(new IdentityUser()
            {
                Email = "refkyw@gmail.com",
                UserName = "refky.wahib@gmail.com",
                PhoneNumber = "0423177197"
            });

            Console.WriteLine(result.Succeeded);
        }
    }
}
