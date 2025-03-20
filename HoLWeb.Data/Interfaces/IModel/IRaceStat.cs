using HoLWeb.DataLayer.Models;

namespace HoLWeb.DataLayer.Interfaces.IModel
{
    public interface IRaceStat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AtributEnum Atribut { get; set; }
        public int RangeLow { get; set; }
        public int RangeHigh { get; set; }
        public int Correction { get; set; }

    }
}

