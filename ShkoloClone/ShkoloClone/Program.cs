using Microsoft.Extensions.Hosting;
using RazorConsole.Core;
using ShkoloClone.Data;
using ShkoloClone.User_Interface;

namespace ShkoloClone
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args)
                .UseRazorConsole<>();
            IHost host = hostBuilder.Build();
            await host.RunAsync();
        }
    }
}
