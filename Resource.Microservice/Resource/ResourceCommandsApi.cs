using System.Threading.Tasks;
using Resource.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Resource.Microservice.Resource
{
    [Route("/resource")]
    public class ResourceCommandsApi : Controller
    {
        private readonly ResourceApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ResourceCommandsApi>();

        public ResourceCommandsApi(
            ResourceApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        public Task<IActionResult> Post(Commands.V1.CreateResource request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("Name")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateName request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("ResourceNo")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateResourceNo request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("Price")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateResourcePrice request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("IsDeleted")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.ResourceDeleted request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

    }
}
