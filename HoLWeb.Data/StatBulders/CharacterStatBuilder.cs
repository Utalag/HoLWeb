using HoLWeb.DataLayer.Models;
using HoLWeb.DataLayer.Models.GeneralAttributes;

namespace HoLWeb.DataLayer.StatBulders
{
    public class CharacterStatBuilder : StatBuilder<CharacterStat>
    {
        public CharacterStatBuilder() : base()
        {
        }
        public CharacterStatBuilder SetCorrection(EnhancedAtributEnum enhancAttribut)
        {
            stat.PrimarAtribut = enhancAttribut;
            return this;
        }
        public CharacterStatBuilder SetAttributePoints(int attributePoints)
        {
            stat.AttributePoints = attributePoints;
            return this;
        }
        public CharacterStatBuilder SetDiceRoll(int diceRoll)
        {
            stat.DiceRoll = diceRoll;
            return this;
        }
        public CharacterStatBuilder SetAtributValue(int atributValue)
        {
            stat.AtributValue = atributValue;
            return this;
        }
        public CharacterStatBuilder SetBonus(int bonus)
        {
            stat.Bonus = bonus;
            return this;
        }
    }
}
