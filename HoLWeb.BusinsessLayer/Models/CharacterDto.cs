using HoLWeb.DataLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace HoLWeb.BusinessLayer.Models
{
    public class CharacterDto
    {


        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;       
        public string Description { get; set; } = string.Empty; 
        public int Profipoints { get; set; }
        public int RaceId { get; set; }                                           


        public int WorldId { get; set; }
        public int NarrativeId { get; set; }
        public int ThumbnailImageId { get; set; }

        public int StrengthStatId { get; set; }
        public int AgilityStatId { get; set; }
        public int ConstitutionStatId { get; set; }
        public int IntelligenceStatId { get; set; }
        public int CharismaStatId { get; set; }

        public List<int> IndividualProfessionSkillIds { get; set; } = new List<int>();


        // navigation properties
        [JsonIgnore][NotMapped] public ThumbnailImageDto? ThumbnailImage { get; set; } = new ThumbnailImageDto();
        [JsonIgnore][NotMapped] public List<ProfessionSkill>? IndividualProfessionSkills { get; set; } = new List<ProfessionSkill>();

        [NotMapped] public CharacterStatDto? Strength { get; set; } = new CharacterStatDto();
        [NotMapped] public CharacterStatDto? Agility { get; set; } = new CharacterStatDto();
        [NotMapped] public CharacterStatDto? Constitution { get; set; } = new CharacterStatDto();
        [NotMapped] public CharacterStatDto? Intelligence { get; set; } = new CharacterStatDto();
        [NotMapped] public CharacterStatDto? Charisma { get; set; } = new CharacterStatDto();


        // ----------------------- NOT SAVE TO DATABASE -------------------
        [JsonIgnore][NotMapped] public Dictionary<int,int> AtributBonus { get; } = new Dictionary<int,int>()
        {
            [1] = -5,
            [2] = -4,
            [3] = -4,
            [4] = -3,
            [5] = -3,
            [6] = -2,
            [7] = -2,
            [8] = -1,
            [9] = -1,
            [10] = 0,
            [11] = 0,
            [12] = 0,
            [13] = 1,
            [14] = 1,
            [15] = 2,
            [16] = 2,
            [17] = 3,
            [18] = 3,
            [19] = 4,
            [20] = 4,
            [21] = 5,
            [22] = 5,
            [23] = 7,
            [24] = 7,
            [25] = 8,
            [26] = 8,
            [27] = 9,
            [28] = 9,
            [29] = 10,
            [30] = 10,
        };

        // atribute labels (CZ: názvy atributů)
        [JsonIgnore][NotMapped] public string strengthLabel = "Síla";
        [JsonIgnore][NotMapped] public string agilityLabel = "Obratnost";
        [JsonIgnore][NotMapped] public string constitutionLabel = "Odolnost";
        [JsonIgnore][NotMapped] public string intelligenceLabel = "Inteligence";
        [JsonIgnore][NotMapped] public string charismaLabel = "Charisma";

        // defined primary atributes (CZ: definované primární atributy)
        [JsonIgnore][NotMapped] public int[] EnhancedStrength { get => [11,13]; }
        [JsonIgnore][NotMapped] public int[] EnhancedAgility { get => [13,14]; }
        [JsonIgnore][NotMapped] public int[] EnhancedConstitution { get => [12,13]; }
        [JsonIgnore][NotMapped] public int[] EnhancedIntelligence { get => [12,14]; }
        [JsonIgnore][NotMapped] public int[] EnhancedCharisma { get => [12,13]; }



    }
}