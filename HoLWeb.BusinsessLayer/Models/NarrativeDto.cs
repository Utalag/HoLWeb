using HoLWeb.DataLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Diagnostics;
using HoLWeb.DataLayer.Models.IdentityModels;

namespace HoLWeb.BusinessLayer.Models
{
    [DebuggerDisplay("{NarrativeName}")]
    public class NarrativeDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string NarrativeName { get; set; } = string.Empty;
        public string NarrativeDescription { get; set; } = string.Empty;
        public string Era { get; set; } = string.Empty;
        public int Year { get; set; }

        public int WorldId { get; set; }
        public int ThumbnailImageId { get; set; }
        public List<int> RaceIds { get; set; } = new List<int>(); // just an information list

        public List<int> CharacterIds { get; set; } = new List<int>();
        public List<int> ProfessionModulIds { get; set; } = new List<int>();
        public string? GameMasterGuid { get; set; } = string.Empty;
        public List<Guid>? PlayersGuids { get; set; } = new List<Guid>();



        [JsonIgnore][NotMapped] public ThumbnailImageDto? ThumbnailImage { get; set; } = new ThumbnailImageDto();
        [JsonIgnore][NotMapped] public World World { get; set; } = new World();
        [JsonIgnore][NotMapped] public List<Character> Characters { get; set; } = new List<Character>();
        [JsonIgnore][NotMapped] public List<ProfessionModul> ProfessionModules { get; set; } = new List<ProfessionModul>();

    }


}
