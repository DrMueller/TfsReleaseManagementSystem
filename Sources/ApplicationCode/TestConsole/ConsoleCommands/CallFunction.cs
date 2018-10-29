using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Newtonsoft.Json;

namespace Mmu.Trms.TestConsole.ConsoleCommands
{
    public class CallFunction : IConsoleCommand
    {
        public string Description { get; } = "Call Function";
        public ConsoleKey Key { get; } = ConsoleKey.D2;

        public async Task ExecuteAsync()
        {
            var result = await AzureFunctions.Areas.Functions.CreateRelease.ExecuteAsync(null, null);
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}