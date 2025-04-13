using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace HoLWeb.BusinessLayer.Managers
{
    public class DictionariesManager(
        IRaceRepository raceRepository,
        ICharacterRepository characterRepository,
        IProfessionModulRepository professionModulRepository,
        IProfessionSkillRepository professionSkillRepository,
        INarrativeRepository narrativeRepository,
        IWorldRepository worldRepository,
        UserManager<ApplicationUser> userManager) : IDictionariesManager
    {
        private readonly IRaceRepository raceRepository = raceRepository;
        private readonly ICharacterRepository characterRepository = characterRepository;
        private readonly IProfessionModulRepository professionModulRepository = professionModulRepository;
        private readonly IProfessionSkillRepository professionSkillRepository = professionSkillRepository;
        private readonly INarrativeRepository narrativeRepository = narrativeRepository;
        private readonly IWorldRepository worldRepository = worldRepository;
        private readonly UserManager<ApplicationUser> userManager = userManager;


        public async Task<Dictionary<int,string>> GetRaceNamesDictionary()
        {
            Dictionary<int,string> result = new();
            var races = await raceRepository.AllAsync();
            foreach(var item in races)
            {
                result.Add(item.Id,item.RaceName);
            }
            return result;
        }
        public async Task<Dictionary<int,string>> GetNarrativNamesDictionary()
        {
            Dictionary<int,string> result = new();
            var narratives = await narrativeRepository.AllAsync();
            foreach(var item in narratives)
            {
                result.Add(item.Id,item.NarrativeName);
            }
            return result;
        }
        public async Task<Dictionary<int,string>> GetWorldNamesDictionary()
        {
            Dictionary<int,string> result = new();
            var worlds = await worldRepository.AllAsync();
            foreach(var item in worlds)
            {
                result.Add(item.Id,item.WorldName);
            }
            return result;
        }

        public async Task<Dictionary<string,string>> GetNickNamesDictionary()
        {
            Dictionary<string,string> result = new();
            var users = userManager.Users.ToList();
            foreach(var user in users)
            {
                result.Add(user.Id.ToString(),user.UserName);
            }
            return await Task.FromResult(result);
        }



    }


}
