using HoLWeb.DataLayer.Interfaces.IModel;
using HoLWeb.DataLayer.Models;

namespace HoLWeb.BusinessLayer.Models
{
    public class RaceStatDto : IRaceStat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AtributEnum Atribut { get; set; }
        public int RangeLow { get; set; }
        public int RangeHigh { get; set; }
        public int Correction { get; set; }

    }
}
