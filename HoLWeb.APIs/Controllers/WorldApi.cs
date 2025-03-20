using HoLWeb.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HoLWeb.BusinessLayer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HoLWeb.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class WorldApi(IWorldManager worldManager) : ControllerBase
    {

        private readonly IWorldManager worldManager = worldManager;

        [HttpGet]
        public async Task<IEnumerable<WorldDto>> WorldGet()
        {
            return await worldManager.GetAllDataAsync();

        }



    }
}


