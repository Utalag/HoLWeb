using HoLWeb.DataLayer.Models.IdentityModels;

namespace HoLWeb.Security
{
    public class Policy
    {
        public const string AdminOnly = nameof(AdminOnly);          // kompletní správa
        public const string PJOnly = nameof(PJOnly);                // správa NPC, příběhů a scénářů a svých hráčů
        public const string PlayerOnly = nameof(PlayerOnly);        // tvorba hráčských postav možnost hrát 
        public const string UserOnly = nameof(UserOnly);            // práve jen k nahlížení 
        public const string GuestOnly = nameof(GuestOnly);          // ?? zatím nevím co sem dát


        public static void SetPolicies(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy(Policy.AdminOnly,policy => policy.RequireRole(ApplicationRole.Admin));
                options.AddPolicy(Policy.PJOnly,policy => policy.RequireRole(ApplicationRole.Admin,ApplicationRole.PJ));
                options.AddPolicy(Policy.PlayerOnly,policy => policy.RequireRole(ApplicationRole.Admin,ApplicationRole.Player));
                options.AddPolicy(Policy.UserOnly,policy => policy.RequireRole(ApplicationRole.Admin,ApplicationRole.User));

            });

            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("Spectator",policy => policy.RequireClaim("GameRole",ClaimName.Spectator));
                options.AddPolicy("Player",policy => policy.RequireClaim("GameRole",ClaimName.Player));
                options.AddPolicy("Founder",policy => policy.RequireClaim("GameRole",ClaimName.GameMaster));
            });
        }
    }
}
