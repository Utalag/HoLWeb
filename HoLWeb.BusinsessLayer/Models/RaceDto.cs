using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace HoLWeb.BusinessLayer.Models
{
        [DebuggerDisplay("ID:{Id},{RaceName}")]
    public class RaceDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Display(Name = "Název rasy"), Required(ErrorMessage = "Jméno musí mít minimílně 2 znaky"),]
        public string RaceName { get; set; } = string.Empty;

        [Display(Name = "Popis rasy")]
        public string RaceDescription { get; set; } = string.Empty;

        [Display(Name = "Velikost")]
        [RegularExpression(@"^[A-D]",ErrorMessage = "Povolené znaky jsou A,B,C,D,E")]
        public string RaceSize { get; set; } = string.Empty;

        [Display(Name = "Pohyblivost")]
        public int Mobility { get; set; }

        [Display(Name = "Specíální dovednost")]
        public string? SpecialAbilities { get; set; }

        [Display(Name = "Popis specíální dovednosti")]
        public string? SpecialAbilitiesDescription { get; set; } = string.Empty;

        [Display(Name = "Minimální váha")]
        public int WeightMin { get; set; } // váha

        [Display(Name = "Maximální váha")]
        public int WeightMax { get; set; }

        [Display(Name = "Minimální výška")]
        public int BodyHeightMin { get; set; } //výška rasy
        [Display(Name = "Maximální výška")]
        public int BodyHeightMax { get; set; }

        public int? StrengthStatId { get; set; }
        public int? AgilityStatId { get; set; }
        public int? ConstitutionStatId { get; set; }
        public int? IntelligenceStatId { get; set; }
        public int? CharismaStatId { get; set; }
        public int ThumbnailImageId { get; set; }

        public virtual RaceStatDto? StrengthStat { get; set; }
        public virtual RaceStatDto? AgilityStat { get; set; }
        public virtual RaceStatDto? ConstitutionStat { get; set; }
        public virtual RaceStatDto? IntelligenceStat { get; set; }
        public virtual RaceStatDto? CharismaStat { get; set; }

        public List<int> WorldIds { get; set; } = new List<int>();

        public ThumbnailImageDto? ThumbnailImage { get; set; }


    }
}
