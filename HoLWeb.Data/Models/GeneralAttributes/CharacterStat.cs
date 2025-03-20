using HoLWeb.DataLayer.Interfaces.IModel;

namespace HoLWeb.DataLayer.Models.GeneralAttributes
{
    public class CharacterStat : GeneralAttribut, ICharacterStat
    {

        public EnhancedAtributEnum PrimarAtribut { get; set; } = EnhancedAtributEnum.basic;
        public int AttributePoints { get; set; }
        public int DiceRoll { get; set; }
        public int AtributValue { get; set; }
        public int Bonus { get; set; }
        public string Author { get; set; } = string.Empty;




        public override GeneralAttribut[] Initial(int nextId)
        {
            int id = nextId;
            var stat = new CharacterStat[]
                {
                new() {Id=id++,Atribut=AtributEnum.strength    , RangeLow=3 , RangeHigh=8 ,AtributValue=6 ,Bonus=-2, NumberOfDice=1,DiceRoll=4,AttributePoints=30,Name="Pokusňák"},
                new() {Id=id++,Atribut=AtributEnum.agility     , RangeLow=11, RangeHigh=16,AtributValue=13,Bonus= 1, NumberOfDice=1,DiceRoll=4,AttributePoints=55,Name="Pokusňák"},
                new() {Id=id++,Atribut=AtributEnum.constitution, RangeLow=8 , RangeHigh=13,AtributValue=11,Bonus= 0, NumberOfDice=1,DiceRoll=4,AttributePoints=40,Name="Pokusňák"},
                new() {Id=id++,Atribut=AtributEnum.intelligence, RangeLow=10, RangeHigh=15,AtributValue=13,Bonus= 1, NumberOfDice=1,DiceRoll=4,AttributePoints=50,Name="Pokusňák"},
                new() {Id=id++,Atribut=AtributEnum.charisma    , RangeLow=8 , RangeHigh=18,AtributValue=14,Bonus= 1, NumberOfDice=2,DiceRoll=8,AttributePoints=40,Name="Pokusňák"},
                };
            return stat;
        }
    }
}
