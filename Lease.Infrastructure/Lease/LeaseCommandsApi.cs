using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lease.Infrastructure
{
    [Route("/lease")]
    public class LeaseCommandsApi : Controller
    {
        private readonly LeaseApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<LeaseCommandsApi>();

        public LeaseCommandsApi(LeaseApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public Task<IActionResult> Post(Commands.V1.CreateLease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("street")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateLeaseStreet request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("zipcode")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateLeaseZipCode request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("city")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateLeaseCity request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);


        [Route("datecreated")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateDateCreated request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("deletelease")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.DeleteLease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("delivery")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateIsDelivery request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("paid")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateIsPaid request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        
        [Route("price")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateTotalPrice request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

    }
}