using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QLBanHang.Models;

[assembly: OwinStartupAttribute(typeof(QLBanHang.Startup))]
namespace QLBanHang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //InitUserRole();
        }
        private void InitUserRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin2@qlbh.com";
                user.Email = "admin2@qlbh.com";
                string pass = "123456";
                var chkUser = userManager.Create(user, pass);
                if (chkUser.Succeeded)
                    userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
