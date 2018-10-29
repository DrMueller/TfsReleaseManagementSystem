using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctionExecution;
using Mmu.Trms.Application.Areas.Dtos;
using Mmu.Trms.Application.Areas.Services;
using Mmu.Trms.AzureFunctions.Infrastructure;
using Newtonsoft.Json;

namespace Mmu.Trms.AzureFunctions.Areas.Functions
{
    public static class CreateRelease
    {
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Needed by the Framework")]
        [FunctionName("CreateRelease")]
        public static Task<IActionResult> ExecuteAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger logger)
        {
            FunctionsInitializationService.Initialize();
            return AzureFunctionExecutionContext.ExecuteAsync<IReleaseCreationService>(
                async service =>
                {
                    var requestBody = new StreamReader(req.Body).ReadToEnd();
                    var patchWorkItemDto = JsonConvert.DeserializeObject<ReleaseConfigurationDto>(requestBody);
                    await service.CreateReleaseAsync(patchWorkItemDto);
                    return new OkResult();
                });
        }
    }
}
