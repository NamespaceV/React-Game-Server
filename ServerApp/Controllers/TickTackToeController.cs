using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.ServerApp.CQS.Core;
using Server.ServerApp.CQS.TickTackToe;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TickTackToeController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public TickTackToeController(
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<string>> ListGames()
        {
            return await _queryDispatcher.DispatchAsync<ListGamesQuery, List<string>> (new ListGamesQuery());
        }

        [HttpGet]
        [Route("create")]
        public async Task<List<string>> CreateGame()
        {
            await _commandDispatcher.DispatchAsync(new CreateGameCommand());
            return await ListGames();
        }
    }
}
