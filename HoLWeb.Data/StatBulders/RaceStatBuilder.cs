using HoLWeb.DataLayer.Models.GeneralAttributes;

namespace HoLWeb.DataLayer.StatBulders
{
    public class RaceStatBuilder : StatBuilder<RaceStat>
    {
        public RaceStatBuilder() : base()
        {

        }
        public RaceStatBuilder SetCorrection(int correction)
        {
            stat.Correction = correction;
            return this;
        }
        //public RaceStatBuilder SetRaceId(int raceId)
        //{
        //    stat.Id = raceId;
        //    return this;
        //}

    }
}
