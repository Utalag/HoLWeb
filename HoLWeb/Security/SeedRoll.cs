using HoLWeb.DataLayer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace HoLWeb.Security
{
    public static class SeedRoll
    {
        public static async void Seed(WebApplication app)
        {
            using(var scope = app.Services.CreateScope())
            { 
                var rolleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                foreach(var role in ApplicationRole.AllRoles)
                {
                    //Skips if role already exists
                    if(await rolleManager.RoleExistsAsync(role)) continue;
                    
                    var r = await rolleManager.CreateAsync(new ApplicationRole { Name = role });

                    //Log result
                    if(r.Succeeded)
                    {
                        app.Logger.LogInformation($"Role {role} created",role);
                    }
                    else
                    {
                        foreach(var error in r.Errors)
                        {
                           app.Logger.LogError($"Error creating role {role}: {error.Description}",role,error.Code,error.Description);
                        }
                    }

                }
            }
        }
    }
}
