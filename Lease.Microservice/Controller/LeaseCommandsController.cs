using System.Threading.Tasks;
using Lease.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lease.Microservice.Lease
{
    [Route("/lease")]
    public class LeaseCommandsController : Controller
    {
        private readonly LeaseApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<LeaseCommandsController>();

        public LeaseCommandsController(LeaseApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public Task<IActionResult> Post(LeaseOrderCommands.V1.CreateLease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("street")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.UpdateLeaseStreet request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("zipcode")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.UpdateLeaseZipCode request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("city")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.UpdateLeaseCity request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);


        [Route("datecreated")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.UpdateDateCreated request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("deletelease")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.DeleteLease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("delivery")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.UpdateIsDelivery request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("paid")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.UpdateIsPaid request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        
        [Route("price")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.UpdateTotalPrice request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

    }
}