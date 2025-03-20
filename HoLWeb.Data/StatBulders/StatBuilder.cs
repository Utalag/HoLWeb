using HoLWeb.DataLayer.Models;
using HoLWeb.DataLayer.Models.GeneralAttributes;

namespace HoLWeb.DataLayer.StatBulders
{
    public abstract class StatBuilder<T> where T : GeneralAttribut, new()
    {
        protected T stat;
        protected StatBuilder()
        {
            stat = new T();
        }
        public virtual StatBuilder<T> SetId(int id)
        {
            stat.Id = id;
            return this;
        }
        public virtual StatBuilder<T> SetName(string name)
        {
            stat.Name = name;
            return this;
        }
        public virtual StatBuilder<T> SetAtribut(AtributEnum atribut)
        {
            stat.Atribut = atribut;
            return this;
        }
        public virtual StatBuilder<T> SetRangeLow(int rangeLow)
        {
            stat.RangeLow = rangeLow;
            return this;
        }
        public virtual StatBuilder<T> SetRangeHigh(int rangeHigh)
        {
            stat.RangeHigh = rangeHigh;
            return this;
        }
        public virtual StatBuilder<T> SetNumberOfDice(int numberOfDice)
        {
            stat.NumberOfDice = numberOfDice;
            return this;
        }

        public virtual T Build()
        {
            return stat;
        }
    }
}
