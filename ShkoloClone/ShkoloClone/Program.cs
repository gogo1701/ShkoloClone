using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorConsole.Core;
using RazorConsole.Components;
using ShkoloClone.Data;
using ShkoloClone.Models;
using ShkoloClone.User_Interface;
using Counter.Components;

namespace ShkoloClone
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args).UseRazorConsole<HomePage>();
   
            var host = hostBuilder.Build();
            await host.RunAsync();
        }
    }
}
