using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OrleansHelloWorld.Silo;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .UseOrleans(silo =>
            {
                silo.UseLocalhostClustering()
                    .ConfigureLogging(logging => logging.AddConsole());
            })
            .UseConsoleLifetime();

        using var host = builder.Build();

        await host.RunAsync();
    }
}