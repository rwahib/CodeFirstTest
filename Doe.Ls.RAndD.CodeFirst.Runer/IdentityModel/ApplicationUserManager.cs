using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Doe.Ls.RAndD.CodeFirst.Runer.IdentityModel
{
    public class ApplicationUserManager: UserManager<ApplicationUser,string>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, string> store) : base(store)
        {
        }

        public static ApplicationUserManager Create()
        {
            var identityDbContext = new IdentityDbContext<ApplicationUser>("IdentityConnection");
            var userStore = new UserStore<ApplicationUser>(identityDbContext);
            return new ApplicationUserManager(userStore);

        }
    }
}
