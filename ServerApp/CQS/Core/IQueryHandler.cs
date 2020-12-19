using System.Threading.Tasks;

namespace Server.ServerApp.CQS.Core
{
    internal interface IQueryHandler<T, R>
    {
        public Task<R> HandleAsync(T query);
    }
}