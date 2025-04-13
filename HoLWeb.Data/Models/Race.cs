using HoLWeb.DataLayer.Models.GeneralAttributes;

namespace HoLWeb.DataLayer.Models
{
    public enum RaceSizeEnum
    {
        A, B, C, D
    }



    public class Race
    {

        public int Id { get; set; }
        public string RaceName { get; set; } = string.Empty;
        public string RaceDescription { get; set; } = string.Empty;
        public RaceSizeEnum RaceSize { get; set; }
        public int Mobility { get; set; }
        public string? SpecialAbilities { get; set; }
        public string? SpecialAbilitiesDescription { get; set; } = string.Empty;

        public int WeightMin { get; set; }
        public int WeightMax { get; set; }

        public int BodyHeightMin { get; set; }
        public int BodyHeightMax { get; set; }


        public virtual List<World>? Worlds { get; set; } = new List<World>();

        public int? StrengthStatId { get; set; }
        public int? AgilityStatId { get; set; }
        public int? ConstitutionStatId { get; set; }
        public int? IntelligenceStatId { get; set; }
        public int? CharismaStatId { get; set; }

        public virtual RaceStat? StrengthStat { get; set; }
        public virtual RaceStat? AgilityStat { get; set; }
        public virtual RaceStat? ConstitutionStat { get; set; }
        public virtual RaceStat? IntelligenceStat { get; set; }
        public virtual RaceStat? CharismaStat { get; set; }

        public virtual ThumbnailImage? ThumbnailImage { get; set; }
        public int? ThumbnailImageId { get; set; }



        /// <summary>
        /// inicializace databáze
        /// </summary>
        /// <returns></returns>
        public Race[] Initial()
        {


            var race = new Race[]
            {
                new() {
                Id = 1,
                RaceName       ="Hobbit",
                RaceDescription="Hobiti jsou malým, veselým nárůdkem. Jsou ještě menší než trpaslíci, chlupatí a jaksi \"dobrácky kulaťoučcí\". Žijí zpravidla v úrodných údolích, kde si ve stráních budují komfortní nory a doupata. Rozhodně nejsou nijak zvlášť silní, ale zato jsou velmi obratní a povětšinou inteligentní. Dobrodružství příliš nevyhledávají, protože mají rádi pohodlí, dobré jídlo a silné piti. Jestliže se však jednou přece jen vydají na cesty, patří k těm nejlepším zlodějům, jaké si jen dovedeš představit. Hobiti mají také zvláštní psychickou schopnost, díky které dokážou \"vycítit\" na dálku většinu živých tvorů. Této zvláštní vlastnosti říkají mezi sebou \"čich\", a přestože jejich pohodlnickým životem již dosti zakrněla, dokážou díky ní lokalizovat živou bytost, dokonce i když je od nich oddělena například železnou stěnou. Přestože hobiti nejsou zbabělí, jen neradi přistupují na boj tváří v tvář a raději používají své kuše než těžké meče nebo halapartny.",
                RaceSize       =RaceSizeEnum.A,
                WeightMin=40,WeightMax=60,BodyHeightMin=70,BodyHeightMax=120,
                Mobility       =10,
                SpecialAbilities="Čich",
                SpecialAbilitiesDescription="Tato schopnost mu umožňuje vycítit přítomnost většiny živých tvorů což zdaleka neznamená všechny tvory, například na kostlivce je hobitův čich krátký), není ale schopen vycítit různé plísně, houby a jiné rostliny ani běžné tvory velikosti A0 (respektive byl by schopen je cítit, ale nevnímá je, asi jako člověk obvykle nevnímá mravence v trávě, ačkoliv je schopen je vidět). Největší vzdálenost, na jakou to je schopen dokázat, je 12 sáhů. Tato vzdálenost se zkracuje o 1 sáh za každých 30 coulů dřeva, 10 coulů kamene nebo 1 coul kovu. Hobit není schopen určit, o jakého tvora se jedná, ani jak je přesně daleko, ale pozná, do jaké třídy velikosti patří. Hobit má neurčitý pocit cizí přítomnosti. Hobit nemůže svou zvláštní schopnost používat, pokud spí. V bdělém stavu se na ni nemusí soustředit, ale nebude-li svému okolí věnovat dostatečnou pozornost, může mu něco uniknout. Hobita při používání čichu neruší přítomnost ostatních členů družiny.",
                StrengthStatId = 1,
                AgilityStatId = 2,
                ConstitutionStatId = 3,
                IntelligenceStatId = 4,
                CharismaStatId = 5,
               },

                new (){
                Id = 2,
                RaceName       ="Gnom",
                RaceDescription="Gnómové jsou zvláštní rasou, o které se ví téměř jistě, že vznikla kdysi v dávných dobách splynutím části plemene trpaslíků s hobity. Podobně jako hobiti také gnómové jsou velmi obratní a poměrně chytří. Po trpaslících zase zdědili jejich nezdolnost a z části také lásku ke zlatu a drahým kamenům. Žijí v horách i v nížinách, ale nemilují podzemí, a proto si staví drobné kamenné domy, většinou daleko od velkých měst a obchodních cest. Přestože jen málokterý z nich se stane dobrým bojovníkem, dokážou v boji velmi dobře zacházet jak se sekerou, tak i s kuší. Mnoho z nich také nachází potěšení v různém bylinkářství a alchymii, ale stejně tak dobře se mohou uplatnit třeba jako zloději.",
                RaceSize       =RaceSizeEnum.A,
                WeightMin=50,WeightMax=75,BodyHeightMin=90,BodyHeightMax=130,
                Mobility       =9,
                SpecialAbilities="",
                StrengthStatId = 6,
                AgilityStatId = 7,
                ConstitutionStatId = 8,
                IntelligenceStatId = 9,
                CharismaStatId = 10,
                },

                new (){
                    Id = 3,
                RaceName       ="Trpaslík",
                RaceDescription="Trpaslíci jsou jednou z nejznámějších člověku podobných ras. Jsou menší, podsadití, zocelení dlouhými věky strávenými v nehostinných pustinách. Jejich větrem ošlehané tváře snad vždy zdobí hnědé až černé vousy, které jim však, stejně jako vlasy, poměrně záhy šedivějí. Sídlí v horách, zpravidla daleko od civilizace. Díky infravidění vidí v omezené míře i ve tmě, a proto mohou pod zemí budovat rozsáhlé skalní komplexy šachet, jeskyní a sálů, kde těží drahé kameny, stříbro a především svoje milované zlato. Trpaslíci většinou postrádají jakýkoliv smysl pro humor, jsou vždy vážní a někdy až příliš sebejistí. Dané slovo dodrží, zejména kyne-li jim z toho nějaká výhoda. Jejich nejoblíbenější zbraní je válečná sekera. V boji jsou nesmírně stateční a jen neradi ustupují z prohrané bitvy. Brání-li trpaslík svoji hroudu zlata, neustoupí ani před rozvztekleným, vyhladovělým ohnivým drakem.",
                RaceSize       =RaceSizeEnum.A,
                WeightMin=55,WeightMax=100,BodyHeightMin=110,BodyHeightMax=140,
                Mobility       =8,
                SpecialAbilities="Infravidění",
                SpecialAbilitiesDescription="Infravidění má dosah 20 sáhů a neproniká žádným materiálem, kterým by neproniklo obyčejné světlo. Ve slunečním světle (nebo ve světle stejné intenzity vyvolaném kouzlem) je infravidění nepoužitelné. Infravidění rovněž není použitelné za mlhy (a to ani ve tmě), podobně jako normální zrak. Pod vodou je infravidění použitelné, ale nikoli skrz vodní hladinu, která infrazáření podobně jako světlo a zvuk láme a všelijak zkresluje. Infravidění je schopnost vidět teplo. I v naprosté tmě trpaslík zřetelně uvidí každého živého tvora s teplou krví - skřeta i zatoulaného psa- jako jasně červenou skvrnu. Hady, červy a jiné studenokrevné živočichy trpaslík neuvidí, pokud se nebude dívat velmi pozorně. Infraviděním rovněž nelze zpozorovat některé nestvůry magické podstaty, jež nevydávají teplo (například kostlivce). lnfraviděním zpravidla nelze určovat ani tvar místností, ani jejich obsah. Výjimkou mohou být věci, které jsou studenější nebo teplejší než okolí. Například jezírko studené vody trpaslík uvidí jako tmavě modrou skvrnu, nedávno vyhaslé ohniště jako tmavě červenou. Trpaslík se nemusí na infravidění soustřeďovat. V situaci, kdy mu nebude stačit obyčejný zrak, začne automaticky infravidění využívat. I když tobě se takové zobrazení může zdát nejasné a nepochopitelné, trpaslík, který ho má jako vrozenou schopnost, se v něm poměrně dobře vyzná. Přechod od normálního vidění k infra vidění lze přirovnat k překrývání fotografií. Jakmile v šeru trpaslík přestává vidět skutečné barvy, začíná vnímat infrabarvy.",
                StrengthStatId = 11,
                AgilityStatId = 12,
                ConstitutionStatId = 13,
                IntelligenceStatId = 14,
                CharismaStatId = 15,
               },

                new (){
                    Id = 4,
                RaceName       ="Elf",
                RaceDescription="Elfové jsou známou rasou, žijící zpravidla hluboko v lesích nebo odlehlých údolích a roklinách. Jsou menší než lidé a zdaleka ne tak robustní. Pro své většinou plavé vlasy a jemné rysy obličeje jsou pokládáni za velmi krásné až poněkud změkčilé. Protože jsou velmi inteligentní, jen neradi bojují avšak jsou-li k boji donuceni, mohou být nebezpečnými soupeři. Díky své obratnosti dovedou dobře zacházet zejména s lukem a se střelnými zbraněmi vůbec. Největší potěšeni jim však činí studium a učení se kouzlům, a proto z jejich řad vzešlo již mnoho známých kouzelníků. Také milují krásné věci, ale od trpaslíků (které mimochodem nemají příliš v lásce) se liší především tím, že krásu hned nepřepočítávají na zlaťáky. Elfové jsou vesměs velmi čestní a spravedliví a nikdy se mezi nimi nevyskytují jedinci, pro které by zlo bylo přirozenou podstatou jejich osobnosti.",
                RaceSize       =RaceSizeEnum.B,
                WeightMin=50,WeightMax=85,BodyHeightMin=145,BodyHeightMax=180,
                Mobility       =12,
                SpecialAbilities="Dlouhověkost",
                StrengthStatId = 16,
                AgilityStatId = 17,
                ConstitutionStatId = 18,
                IntelligenceStatId = 19,
                CharismaStatId = 20,
               },

                new (){
                    Id = 5,
                RaceName       ="Člověk",
                RaceDescription="Lidé jsou snad nejrozšířenější rasou, žijící jak v oblastech hor, tak i ve stepích, lesích a tundrách. Budují rozsáhlá sídla, ať už města či vesnice, která zpravidla leží na velkých obchodních křižovatkách. Lidé jsou velmi houževnatí, nacházejí uplatnění v celé škále povoláni. Většina z nich se zabývá především zemědělstvím a řemeslnou výrobou, ale najdete mezi nimi i zdatné lovce a zkušené dobrodruhy všeho druhu.",
                RaceSize       =RaceSizeEnum.B,
                WeightMin=65,WeightMax=115,BodyHeightMin=165,BodyHeightMax=210,
                Mobility       =11,
                SpecialAbilities="",
                StrengthStatId = 21,
                AgilityStatId = 22,
                ConstitutionStatId = 23,
                IntelligenceStatId = 24,
                CharismaStatId = 25,
                },

                new (){
                    Id= 6,
                RaceName       ="Barbar",
                RaceDescription="Barbaři jsou v podstatě lidé, ale jejich po staletí trvající odloučení od skutečné lidské civilizace způsobilo, že barbar zpravidla není tak inteligentní jako člověk, avšak je silnější a mnohem odolnější. Tyto vlastnosti jej také předurčují k tomu, aby se stal dobrým válečníkem.",
                RaceSize       =RaceSizeEnum.B,
                WeightMin=75,WeightMax=140,BodyHeightMin=175,BodyHeightMax=220,
                Mobility       =12,
                SpecialAbilities="",
                StrengthStatId = 26,
                AgilityStatId = 27,
                ConstitutionStatId = 28,
                IntelligenceStatId = 29,
                CharismaStatId = 30,
                },

                new (){
                    Id = 7,
                RaceName       ="Kroll",
                RaceDescription="Krollové sídlí v horách, tundrách a vůbec v prostředí velmi tvrdém a nehostinném. Dospělý kroll může měřit hodně přes dva metry a zjevem může vzdáleně (velmi vzdáleně) připomínat pračlověka, i když jeho kůže je spíše zrohovatělá než chlupatá. Bezpečně je však poznáte podle jejich nezaměnitelných uší, jimž vděčí za svůj neobvyklý sluch. Krollové jsou silnější než obyčejní lidé, ale také poněkud neohrabaní a zejména o poznání hloupější. Žijí obvykle v nevelkých kmenech, které mezi sebou neustále válčí. V těchto bojích se velmi zdokonalili, a proto nyní patří k nejobávanějším bojovníkům a z jejich kyjů a palcátů jde vskutku příslovečný strach. Po svých divokých předcích kromě jiného podědili také vrozený \"ultrasluch\", který jim umožňuje do jisté míry \"vidět\" (podobně jako netopýrům) i za úplné tmy nebo mlhy. Pokud jde o jejich původ, je možné, že vznikli kdysi dávno spojením skřeta s poloobrem. To by také vysvětlovalo, proč se mezi nimi téměř nikdy nevyskytují jedinci preferující výhradně dobro.",
                RaceSize       =RaceSizeEnum.C,
                WeightMin=100,WeightMax=200,BodyHeightMin=180,BodyHeightMax=245,
                Mobility       =11,
                SpecialAbilities="Ultrasluch",
                SpecialAbilitiesDescription="Jeho zvláštní schopnost se nazývá ultrasluch a připomíná sonar netopýrů. Kroll je schopen vysílat Lidským uchem nezachytitelné zvukové vlnění, které se odráží od zkoumaného předmětu a vrací se zpět ke krollovi. Podle toho, jak odražené vlnění vypadá, je kroll schopen určit vzdálenost a tvar předmětu. Ultrasluch je použitelný v mlze, dokonce i pod vodou (ale ne skrz vodní hladinu, na ní se zvuk láme, odráží a všelijak zkresluje). Krollův ultrasluch má dosah 50 sáhů. To znamená, že kroll je schopen postřehnout jakýkoliv předmět nebo jakéhokoliv hmotného tvora, který je blíž než 50 sáhů a není zastíněn nějakým jiným předmětem nebo tvorem. Bude také schopen zhruba určit jeho vzdálenost a velikost. Kroll nepozná, o jakého tvora jde, ale pozná například, kolik má nohou apod. S předměty v jeskyni a jejím vybavením to je podobné. Krollův ultrasluch je v podstatě stále ještě sluchem, a proto závisí na hluku, který krolla obklopuje. Kroll nemůže používat ultrasluch v prostředí, které je hlučnější než obyčejný lidský hovor. Kroll svůj ultrasluch nepoužívá automaticky. Chce-li tuto svou zvláštní schopnost použít, musí o tom říct Pánovi jeskyně. Prozkoumávání ultrasluchem je stejně rychlé jako pohled. Prostor, který by kroll očima přehlédl během jednoho kola, je schopen za stejnou dobu prozkoumat i ultrasluchem. Kroll je schopen díky svému ultrasluchu vnímat i netopýry (a delfíny a jiné tvory, vybavené sonarem), není ovšem schopen se s nimi nijak dorozumět ani s nimi komunikovat. Tyto cizí signály krollův ultrasluch neruší, není-li jich příliš mnoho. Například uprostřed hejna netopýrů kroll svoji zvláštní schopnost může použít jen stěží.",
                StrengthStatId = 31,
                AgilityStatId = 32,
                ConstitutionStatId = 33,
                IntelligenceStatId = 34,
                CharismaStatId = 35,
                }

        };
            return race;
        }

    }
}

