using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using StudentRecruiter.Models;
using StudentRecruiter.Models.Domain;
using StudentRecruiter.Models.Enums;

namespace StudentRecruiter
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
			
            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

			CreateRolesandUsers();
		}

		private void CreateRolesandUsers()
		{
			ApplicationDbContext context = new ApplicationDbContext();

			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			var adminRole = Role.Admin.ToString();
			if (!roleManager.RoleExists(Role.Admin.ToString()))
			{

				var role = new IdentityRole();
				role.Name = adminRole;
				roleManager.Create(role);

				var user = new ApplicationUser();				
				user.Email = "webrecruiter@gmail.com";
				user.UserName = "webrecruiter@gmail.com";
				string password = "Admin123!";

				var userAdded = UserManager.Create(user, password);

				if (userAdded.Succeeded)
				{
					UserManager.AddToRole(user.Id, adminRole);
				}
			}

		    var candidateRole = Role.Candidate.ToString();
		    if (!roleManager.RoleExists(candidateRole))
		    {
		        var role = new IdentityRole();
		        role.Name = candidateRole;
		        roleManager.Create(role);

		    }

            var managerRole = Role.Manager.ToString();
			if (!roleManager.RoleExists(managerRole))
			{
				var role = new IdentityRole();
				role.Name = managerRole;
				roleManager.Create(role);

			}
		}
	}
}