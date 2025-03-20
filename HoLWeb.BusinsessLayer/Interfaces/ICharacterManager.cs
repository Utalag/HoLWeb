using HoLWeb.DataLayer.Models;
using HoLWeb.BusinessLayer.Models;

namespace HoLWeb.BusinessLayer.Interfaces
{
    public interface ICharacterManager : IGenericManager<CharacterDto>
    {
        CharacterDto SetDefaultAtributeAsRaceRange(CharacterDto character,RaceDto raceData);
        CharacterDto SetOnePrimaryAtribut(CharacterDto character,RaceDto race,AtributEnum atribute,int index = 0);
        //CharacterDto SetOnePrimaryAtribut(CharacterDto character,RaceDto race,AtributEnum atribute,EnhancedAtributEnum enhancedAtribut);
    }
}