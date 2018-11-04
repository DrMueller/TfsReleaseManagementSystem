using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Trms.Application.Areas.Dtos;
using Mmu.Trms.Application.Areas.Services;

namespace Mmu.Trms.TestConsole.ConsoleCommands
{
    public class CreateRelease : IConsoleCommand
    {
        private readonly IReleaseCreationService _releaseCreationService;
        public string Description { get; } = "Create Release";
        public ConsoleKey Key { get; } = ConsoleKey.D1;

        public CreateRelease(IReleaseCreationService releaseCreationService)
        {
            _releaseCreationService = releaseCreationService;
        }

        public async Task ExecuteAsync()
        {
            await _releaseCreationService.CreateReleaseAsync(
                new ReleaseConfigurationDto
                {
                    BuildId = 1172,
                    ParentWorkItemId = 201,
                    BuildVersion = "1.2.3"
                });

            Console.WriteLine("Hello World!");
        }
    }
}