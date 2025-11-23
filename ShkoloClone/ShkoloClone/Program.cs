using Microsoft.Extensions.Hosting;
using RazorConsole.Core;
using ShkoloClone.Data;
using ShkoloClone.Models;
using ShkoloClone.Services;
using ShkoloClone.UI;

namespace ShkoloClone
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args).UseRazorConsole<App>();
            var host = hostBuilder.Build();
            await host.RunAsync();
        }
    }
}
