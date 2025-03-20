using HoLWeb.DataLayer.Models;

namespace HoLWeb.DataLayer.Interfaces.IModel
{
    public interface ICharacterStat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AtributEnum Atribut { get; set; }
        public int RangeLow { get; set; }
        public int RangeHigh { get; set; }
        public int NumberOfDice { get; set; }
        public EnhancedAtributEnum PrimarAtribut { get; set; }
        public int AttributePoints { get; set; }
        public int DiceRoll { get; set; }
        public int AtributValue { get; set; }
        public int Bonus { get; set; }
    }
}
