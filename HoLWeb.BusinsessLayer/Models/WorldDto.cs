using HoLWeb.DataLayer.Models.IdentityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace HoLWeb.BusinessLayer.Models
{
    [DebuggerDisplay("{WorldName}")]
    /// <summary>
    /// Vazební tabulka 
    /// </summary>
    public class WorldDto
    {
        public int Id { get; set; }
        public string WorldName { get; set; } = "Nový";
        public string WorldDescription { get; set; } = string.Empty;
        public int AmountOfMagicInTheWorld { get; set; } = 50;

        public IList<int> RaceIds { get; set; } = new List<int>();
        public IList<int> NarrativeIds { get; set; } = new List<int>();
        public int ThumbnailImageId { get; set; }

        //public List<Guid>? PlayersInWorld { get; set; } = new List<Guid>();
        //public List<Guid>? GameMastersInWorld { get; set; } = new List<Guid>();

        //public List<string>? PlayersNameInWorld { get; set; } = new List<string>();
        //public List<string>? GameMastersNameInWorld { get; set; } = new List<string>();

        public Guid? FounderId { get; set; }
        public string FounderUseName { get; set; } = "System";

        [JsonIgnore][NotMapped] public List<RaceDto> Races { get; set; } = new List<RaceDto>();
        [JsonIgnore][NotMapped] public List<NarrativeDto> Narratives { get; set; } = new List<NarrativeDto>();
        [JsonIgnore][NotMapped] public ThumbnailImageDto ThumbnailImage { get; set; } = new ThumbnailImageDto();
    }

}
