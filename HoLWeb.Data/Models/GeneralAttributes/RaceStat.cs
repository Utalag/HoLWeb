using HoLWeb.DataLayer.Interfaces.IModel;

namespace HoLWeb.DataLayer.Models.GeneralAttributes
{
    public class RaceStat : GeneralAttribut, IRaceStat
    {
        public int Correction { get; set; }


        public override GeneralAttribut[] Initial(int firstId)
        {
            int id = firstId;
            var stat = new RaceStat[]
            {
                // hobbit
                new() {Id=id++,Atribut=AtributEnum.strength    , RangeLow=3 , RangeHigh=8 , Correction=-5, NumberOfDice=1,Name="Hobbit"},
                new() {Id=id++,Atribut=AtributEnum.agility     , RangeLow=11, RangeHigh=16, Correction= 2, NumberOfDice=1,Name="Hobbit"},
                new() {Id=id++,Atribut=AtributEnum.constitution, RangeLow=8 , RangeHigh=13, Correction= 0, NumberOfDice=1,Name="Hobbit"},
                new() {Id=id++,Atribut=AtributEnum.intelligence, RangeLow=10, RangeHigh=15, Correction=-2, NumberOfDice=1,Name="Hobbit"},
                new() {Id=id++,Atribut=AtributEnum.charisma    , RangeLow=8 , RangeHigh=18, Correction= 3, NumberOfDice=2,Name="Hobbit"},

                // gnome
                new() {Id=id++,Atribut=AtributEnum.strength    , RangeLow=5 , RangeHigh=10, Correction=-3, NumberOfDice=1,Name="Gnom"},
                new() {Id=id++,Atribut=AtributEnum.agility     , RangeLow=10, RangeHigh=15, Correction= 1, NumberOfDice=1,Name="Gnom"},
                new() {Id=id++,Atribut=AtributEnum.constitution, RangeLow=10, RangeHigh=15, Correction= 1, NumberOfDice=1,Name="Gnom"},
                new() {Id=id++,Atribut=AtributEnum.intelligence, RangeLow=9 , RangeHigh=14, Correction=-2, NumberOfDice=1,Name="Gnom"},
                new() {Id=id++,Atribut=AtributEnum.charisma    , RangeLow=7 , RangeHigh=12, Correction= 0, NumberOfDice=1,Name="Gnom"},

                // dwarf
                new() {Id=id++,Atribut=AtributEnum.strength    , RangeLow= 7, RangeHigh=12, Correction= 1, NumberOfDice=1,Name="Dwarf"},
                new() {Id=id++,Atribut=AtributEnum.agility     , RangeLow= 7, RangeHigh=12, Correction=-2, NumberOfDice=1,Name="Dwarf"},
                new() {Id=id++,Atribut=AtributEnum.constitution, RangeLow=12, RangeHigh=17, Correction= 3, NumberOfDice=1,Name="Dwarf"},
                new() {Id=id++,Atribut=AtributEnum.intelligence, RangeLow= 8, RangeHigh=13, Correction=-3, NumberOfDice=1,Name="Dwarf"},
                new() {Id=id++,Atribut=AtributEnum.charisma    , RangeLow= 7, RangeHigh=12, Correction=-2, NumberOfDice=1,Name="Dwarf"},

                // elf
                new() {Id=id++,Atribut=AtributEnum.strength    , RangeLow= 6, RangeHigh=11, Correction= 0, NumberOfDice=1,Name="Human"},
                new() {Id=id++,Atribut=AtributEnum.agility     , RangeLow=10, RangeHigh=15, Correction= 1, NumberOfDice=1,Name="Human"},
                new() {Id=id++,Atribut=AtributEnum.constitution, RangeLow= 6, RangeHigh=11, Correction=-4, NumberOfDice=1,Name="Human"},
                new() {Id=id++,Atribut=AtributEnum.intelligence, RangeLow=12, RangeHigh=17, Correction= 2, NumberOfDice=1,Name="Human"},
                new() {Id=id++,Atribut=AtributEnum.charisma    , RangeLow= 8, RangeHigh=18, Correction= 2, NumberOfDice=2,Name="Human"},

                // human
                new() {Id=id++,Atribut=AtributEnum.strength    , RangeLow= 6, RangeHigh=16, Correction= 0, NumberOfDice=2,Name="Elf"},
                new() {Id=id++,Atribut=AtributEnum.agility     , RangeLow= 9, RangeHigh=14, Correction= 0, NumberOfDice=1,Name="Elf"},
                new() {Id=id++,Atribut=AtributEnum.constitution, RangeLow= 9, RangeHigh=14, Correction= 0, NumberOfDice=1,Name="Elf"},
                new() {Id=id++,Atribut=AtributEnum.intelligence, RangeLow=10, RangeHigh=15, Correction= 0, NumberOfDice=1,Name="Elf"},
                new() {Id=id++,Atribut=AtributEnum.charisma    , RangeLow= 2, RangeHigh=17, Correction= 0, NumberOfDice=3,Name="Elf"},

                // barbarian
                new() {Id=id++,Atribut=AtributEnum.strength    , RangeLow=10, RangeHigh=15, Correction= 1, NumberOfDice=1,Name="Barbar"},
                new() {Id=id++,Atribut=AtributEnum.agility     , RangeLow= 8, RangeHigh=13, Correction=-1, NumberOfDice=1,Name="Barbar"},
                new() {Id=id++,Atribut=AtributEnum.constitution, RangeLow=11, RangeHigh=16, Correction= 1, NumberOfDice=1,Name="Barbar"},
                new() {Id=id++,Atribut=AtributEnum.intelligence, RangeLow= 6, RangeHigh=11, Correction= 0, NumberOfDice=1,Name="Barbar"},
                new() {Id=id++,Atribut=AtributEnum.charisma    , RangeLow= 1, RangeHigh=16, Correction=-2, NumberOfDice=3,Name="Barbar"},

                // kroll
                new() {Id=id++,Atribut=AtributEnum.strength    , RangeLow=11, RangeHigh=16, Correction= 3, NumberOfDice=1,Name="Kroll"},
                new() {Id=id++,Atribut=AtributEnum.agility     , RangeLow= 5, RangeHigh=10, Correction=-4, NumberOfDice=1,Name="Kroll"},
                new() {Id=id++,Atribut=AtributEnum.constitution, RangeLow=13, RangeHigh=18, Correction= 3, NumberOfDice=1,Name="Kroll"},
                new() {Id=id++,Atribut=AtributEnum.intelligence, RangeLow= 2, RangeHigh= 7, Correction=-6, NumberOfDice=1,Name="Kroll"},
                new() {Id=id++,Atribut=AtributEnum.charisma    , RangeLow= 1, RangeHigh=11, Correction=-5, NumberOfDice=2,Name="Kroll"},
            };
            return stat;
        }
    }
}
