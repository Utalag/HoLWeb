using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLWeb.BusinessLayer.Interfaces
{
    public interface IDictionariesManager
    {
        Task<Dictionary<int,string>> GetNarrativNamesDictionary();
        Task<Dictionary<string,string>> GetNickNamesDictionary();
        Task<Dictionary<int,string>> GetRaceNamesDictionary();
        Task<Dictionary<int,string>> GetWorldNamesDictionary();
    }
}
