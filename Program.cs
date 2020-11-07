using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(x =>
                    x.UseStartup<Startup>());
            var host = hostBuilder.Build();
            await host.RunAsync();
        }
    }
}
