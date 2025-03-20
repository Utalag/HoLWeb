using HoLWeb.DataLayer.Models.GeneralAttributes;
using HoLWeb.DataLayer.Models.ThumbModels;

namespace HoLWeb.DataLayer.Models
{
    public class Character
    {


        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;        // character name (Cz: Jméno postavy)
        public string Description { get; set; } = string.Empty; // charatcer description (Cz: Popis postavy)
        public int Profipoints { get; set; } // profipoints (Cz: profibody)

        public int[] Visage { get; set; } = new int[2];
        public int[] Mobility { get; set; } = new int[2];



        public int NarrativeId { get; set; }
        public int RaceId { get; set; }
        public int StrengthStatId { get; set; }
        public int AgilityStatId { get; set; }
        public int ConstitutionStatId { get; set; }
        public int IntelligenceStatId { get; set; }
        public int CharismaStatId { get; set; }


        // navigation properties
        public virtual Narrative? Narrative { get; set; }

        public virtual CharacterStat? NavForStrengthStat { get; set; }
        public virtual CharacterStat? NavForAgilityStat { get; set; }
        public virtual CharacterStat? NavForConstitutionStat { get; set; }
        public virtual CharacterStat? NavForIntelligenceStat { get; set; }
        public virtual CharacterStat? NavForCharismaStat { get; set; }

        public virtual ThumbImgCharacter? ThumbnailImage { get; set; }
        public virtual List<ProfessionSkill>? IndividualProfessionSkills { get; set; }

        public Character[] Initial()
        {
            var data = new Character[]
            {
                new Character()
                {
                    Id = 1,
                    Name = "Tester",
                    Description = "Lorem Ypsum",
                    Mobility = new int[] { 11, 0 },
                    Visage = new int[] { 12, 0 },
                    Profipoints = 20,

                    RaceId = 1,
                    StrengthStatId = 36,
                    AgilityStatId = 37,
                    ConstitutionStatId = 38,
                    IntelligenceStatId = 39,
                    CharismaStatId = 40,
                    NarrativeId = 1
                }
            };
            return data;
        }
    }
}
