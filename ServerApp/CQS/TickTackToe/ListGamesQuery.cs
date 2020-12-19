using Server.ServerApp.CQS.Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Server.ServerApp.CQS.TickTackToe
{
    public class ListGamesQuery
    {
    }

    public class ListGamesQueryHandler : IQueryHandler<ListGamesQuery, List<string>>
    {
        public Task<List<string>> HandleAsync(ListGamesQuery query)
        {
            var result =  Directory.EnumerateDirectories(TickTackToeConstants.GamesPath)
                .Select(path => new DirectoryInfo(path).Name)
                .ToList();
            return Task.FromResult(result);
        }
    }
}
