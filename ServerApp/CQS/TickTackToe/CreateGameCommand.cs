using Server.ServerApp.CQS.Core;
using System.IO;
using System.Threading.Tasks;

namespace Server.ServerApp.CQS.TickTackToe
{
    public class CreateGameCommand
    {
    }

    public class CreateGameCommandHandler : ICommandHandler<CreateGameCommand>
    {
        public Task HandleAsync(CreateGameCommand command)
        {
            var gameId = System.Guid.NewGuid();
            new DirectoryInfo(TickTackToeConstants.GamesPath)
                .CreateSubdirectory(gameId.ToString());
            return Task.CompletedTask;
        }
    }
}
