using Microsoft.AspNetCore.Identity;

namespace App.Identity
{
    public static class IdentitySeed
    {
        public static async void Seed(IApplicationBuilder app,IConfiguration configuration)
        {

            // var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>();

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var adminUserName = configuration["IdentitySettings:Admin:UserName"];           
            var adminUser = await userManager.FindByNameAsync(adminUserName!);

            if(adminUser == null)
            {
                var adminEmail = configuration["IdentitySettings:Admin:Email"];
                var adminPassword = configuration["IdentitySettings:Admin:Password"];

                adminUser = new ApplicationUser()
                {
                    UserName = adminUserName,
                    FirstName = adminUserName,
                    LastName = adminUserName,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser,adminPassword!);
                await roleManager.CreateAsync(new IdentityRole{Name=adminUserName});
                await userManager.AddToRoleAsync(adminUser,adminUserName!);

                var customerUserName = configuration["IdentitySettings:Customer:UserName"];
                var customerEmail = configuration["IdentitySettings:Customer:Email"];
                var customerPassword = configuration["IdentitySettings:Customer:Password"];

                var customerUser = new ApplicationUser()
                {
                    UserName = customerUserName,
                    FirstName = customerUserName,
                    LastName = customerUserName,
                    Email = customerEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(customerUser,customerPassword!);
                await roleManager.CreateAsync(new IdentityRole{Name=customerUserName});
                await userManager.AddToRoleAsync(customerUser,customerUserName!);
            }
        }
    }
}