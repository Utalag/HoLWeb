using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HoLWeb.DataLayer.Models
{

    // ----------------- Skill -----------------
    public enum SkillClassEnum
    {
        [Display(Name = "Boj")]
        combatSkill,
        [Display(Name = "Magie")]
        magicSkill,
        [Display(Name = "Lov")]
        huntingSkill,
        [Display(Name = "Alchymie")]
        alchemySkill,
        [Display(Name = "Základní")]
        baseSkill,
        [Display(Name = "Ostatní")]
        otherSkill,
        [Display(Name = "Zlodějství")]
        thiefSkill,
        [Display(Name = "Životy")]
        health,
        [Display(Name = "Vše")]

        statRange,

        allSkill = combatSkill | magicSkill | huntingSkill | alchemySkill | baseSkill | otherSkill | thiefSkill | health,
    }

    //profesion class and subclass
    public enum ProfessionClassEnum
    {
        general,
        [Display(Name = "Válečník")]
        N_warrior,
        [Display(Name = "Šermíř")]
        swordsman,
        [Display(Name = "Zápasník")]
        fightre,
        [Display(Name = "Bojovník")]
        champion,


        [Display(Name = "Kouzelník")]
        N_wizard,
        [Display(Name = "Mág")]
        mage,
        [Display(Name = "Čaroděj")]
        sorcerer,

        [Display(Name = "Lovec")]
        N_hunter,
        [Display(Name = "Hraničář")]
        renger,
        [Display(Name = "Druid")]
        druid,


        [Display(Name = "Alchymista")]
        N_alchemist,
        [Display(Name = "Parofor")]
        pyrofor,
        [Display(Name = "Theurg")]
        theurg,

        [Display(Name = "Zloděj")]
        N_thief,
        [Display(Name = "Vrah")]
        assassin,
        [Display(Name = "Sicco")]
        sicco,
        [Display(Name = "Lupič")]
        rogue,

        [Display(Name = "Lukostřelec")]
        archer,

        allBaseClasee = N_warrior | N_wizard | N_hunter,
        allSubclasse = swordsman | fightre | champion | mage | sorcerer | renger | druid | pyrofor | theurg | assassin | sicco | rogue | archer,
        all = N_warrior | swordsman | fightre | champion | N_wizard | mage | sorcerer | N_hunter | renger | druid | N_alchemist | pyrofor | theurg | N_thief | assassin | sicco | rogue | archer,
    }

    // novices, advanced, master
    public enum LevelGroupEnum
    {
        [Display(Name = "Začítečník")]
        novice,
        [Display(Name = "Pokročilý")]
        advenced,
        [Display(Name = "Expert")]
        master,
        [Display(Name = "Pokročilý a Expert")]
        advacedPlus = advenced | master,
        [Display(Name = "Vše")]
        all = novice | advenced | master,


    }


    // ----------------- Weapon -----------------
    public enum CategoryWeaponEnum
    {
        [Display(Name = "Jednoruční")]
        OneHanded,
        [Display(Name = "Obouruční")]
        TwoHanded,
        [Display(Name = "Dvě jednoruční")]
        DualWielding,

        [Display(Name = "Střelní")]
        Fire,
        [Display(Name = "Vrhací")]
        Throwing,

        [Display(Name = "Magické")]
        Magical,
        [Display(Name = "Exotické")]
        Exotic,

        [Display(Name = "Na blízko")]
        Melee = OneHanded | TwoHanded | DualWielding,
        [Display(Name = "Na dálku")]
        Ranged = Fire | Throwing,
    }

    public enum WeaponTypeEnum
    {
        // One-Handed Weapons
        Sword,              // (Cz: Meč)
        Sabre,              // (Cz: Šavle)
        Dagger,             // (Cz: Dýka)
        Hammer,             // (Cz: Kladivo)
        FistWeapon,         // (Cz: Pěstní zbraň)

        // Two-Handed Weapons
        Greatsword,         // (Cz: Velký meč)
        BattleAxe,          // (Cz: Bojová sekera)
        Warhammer,          // (Cz: Válečné kladivo)
        Halberd,            // (Cz: Halapartna)
        Longbow,            // (Cz: Dlouhý luk)

        // Dual-Wielding Weapons
        PairedDaggers,     // (Cz: Párové dýky)
        PairedSabres,       // (Cz: Párové šavle)
        Nunchaku,          // (Cz: Nunchaku)

        // Ranged Weapons
        Bow,                // (Cz: Luk)
        Crossbow,           // (Cz: Kuše)
        Rifle,              // (Cz: Puška)

        // Magical Weapons
        MagicStaff,         // (Cz: Magický prut)
        MagicRing,          // (Cz: Magický prsten)
        Spellbook,          // (Cz: Kniha kouzel)

        // Exotic Weapons
        Katana,             // (Cz: Katana)
        Sai,                // (Cz: Sai)
        BoStaff             // (Cz: Bojový tyč)
    }

    public enum EnhancedAtributEnum
    {
        [Display(Name = "základ")]
        basic,
        [Display(Name = "Sekundární")]
        secondary,
        [Display(Name = "Primární")]
        primar,

    }
    public enum AtributEnum
    {
        [Display(Name = "Síla")]
        strength = 0,
        [Display(Name = "Obratnost")]
        agility = 1,
        [Display(Name = "Odolnost")]
        constitution = 2,
        [Display(Name = "Inteligence")]
        intelligence = 3,
        [Display(Name = "Charisma")]
        charisma = 4
    }

    public enum ImagesFolderEnum
    {
        None,
        WorldImages,
        CharacterImages,
        RaceImages,
    }

    public static class Enums
    {
        public static string GetEnumDisplayName(Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var memberInfo = enumType.GetMember(enumValue.ToString());
            if(memberInfo.Length > 0)
            {
                var displayAttribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
                if(displayAttribute != null)
                {
                    return displayAttribute.Name;
                }
            }
            return enumValue.ToString();

        }

        private static readonly Dictionary<int,int> _atributBonus = new Dictionary<int,int>()
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

        public static IReadOnlyDictionary<int,int> AtributBonus { get; } = new ReadOnlyDictionary<int,int>(_atributBonus);
    }



}

