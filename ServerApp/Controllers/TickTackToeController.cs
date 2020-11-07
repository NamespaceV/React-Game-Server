using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TickTackToeController : ControllerBase
    {
        private const string _gamesPath = @"F:\Projects\ProjectGameJs\Server\Data\Games";
        public TickTackToeController()
        {
        }

        [HttpGet]
        [Route("list")]
        public List<string> ListGames()
        {
            return Directory.EnumerateDirectories(_gamesPath).Select(path => new DirectoryInfo(path).Name).ToList();
        }

        [HttpGet]
        [Route("create")]
        public List<string> CreateGame()
        {
            var gameId = System.Guid.NewGuid();
            new DirectoryInfo(_gamesPath).CreateSubdirectory(gameId.ToString());
            return ListGames();
        }
    }
}
