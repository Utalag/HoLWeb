using Microsoft.AspNetCore.Identity;
using System.Data;

namespace HoLWeb.DataLayer.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? NickName { get; set; } = string.Empty;
        public string? FullName => $"{FirstName} {LastName}";
        public int Age { get; set; }


        //public virtual IList<World>? WorldGms { get; set; } 
        //public virtual IList<World>? WorldPlayers { get; set; } 
        public virtual IList<World>? EstablishedWorlds { get; set; } 

        public virtual IList<Narrative>? NarrativesAsPlayers { get; set; }
        public virtual IList<Narrative>? NarrativesAsGameMaster { get; set; } 

    }

}
