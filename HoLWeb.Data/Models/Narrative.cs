using HoLWeb.DataLayer.Models.IdentityModels;
using HoLWeb.DataLayer.Models.ThumbModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HoLWeb.DataLayer.Models
{
    public class Narrative
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string NarrativeName { get; set; } = string.Empty;
        public string NarrativeDescription { get; set; } = string.Empty;
        public string Era { get; set; } = string.Empty;
        public int Year { get; set; }
        public int WorldId { get; set; }

        public virtual ThumbImgNarrative? ThumbnailImage { get; set; }
        public virtual World? World { get; set; }
        public virtual List<Character>? Characters { get; set; } = new List<Character>();
        public virtual List<ProfessionModul>? ProfessionModules { get; set; } = new List<ProfessionModul>();

        public virtual List<ApplicationUser>? Players { get; set; } = new List<ApplicationUser>();
        public virtual ApplicationUser? GameMaster { get; set; }
        public Guid? GameMasterId { get; set; }

        public Narrative[] Initial()
        {
            var narration = new Narrative[]
            {
            new Narrative()
            {
                Id = 1,
                NarrativeName = "Čína",
                NarrativeDescription = "Příběh ve vzdálené číně",
                Era ="Císaře C-Chou",
                Year = 679,
                WorldId = 1,
            },
            new Narrative()
            {
                Id = 2,
                NarrativeName = "Řecko",
                NarrativeDescription = "Boje v Persii",
                Era ="III",
                Year = 679,
                WorldId = 1,
            },
            new Narrative()
            {
                Id = 3,
                NarrativeName = "Warhammer",
                NarrativeDescription = "podle Pc hry",
                Era ="XXI",
                Year = 3754,
                WorldId = 2,
            },

            };
            return narration;
        }
    }


}
