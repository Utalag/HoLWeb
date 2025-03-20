using Microsoft.AspNetCore.Identity;

namespace HoLWeb.DataLayer.Models.IdentityModels
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public const string Admin = nameof(Admin);
        public const string PJ = nameof(PJ);
        public const string Player = nameof(Player);
        public const string Host = nameof(Host);
        public const string User = nameof(User);

        public static readonly string[] AllRoles = [Admin,PJ,Player,Host,User ];

    }
}
