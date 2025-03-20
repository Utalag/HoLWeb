using Microsoft.AspNetCore.Identity;

namespace HoLWeb.DataLayer.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? NickName { get; set; } = string.Empty;
        public string? FullName => $"{FirstName} {LastName}";
        public uint Age { get; set; }
        public virtual List<World>? Worlds { get; set; } = new List<World>();
    }

}
