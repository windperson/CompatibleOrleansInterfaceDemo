using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrleansHelloWorld.GrainInterfaces;

var builder = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client => { client.UseLocalhostClustering(); })
    .ConfigureLogging(logging => logging.AddConsole())
    .UseConsoleLifetime();

using var host = builder.Build();

Console.WriteLine("Press any key to start the client...");
Console.ReadKey();
await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();

var friend = client.GetGrain<IHello>(0);
Console.WriteLine("Press any key to send a message to Orleans Silo...");
Console.ReadKey();
var response = await friend.SayHello("Hi friend!");

Console.WriteLine($"""
                   {response}

                   Press any key to exit...
                   """);

Console.ReadKey();

await host.StopAsync();