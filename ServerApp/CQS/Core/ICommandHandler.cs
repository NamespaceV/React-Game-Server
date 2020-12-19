using System.Threading.Tasks;

namespace Server.ServerApp.CQS.Core
{
    internal interface ICommandHandler<T>
    {
        public Task HandleAsync(T command);
    }
}