using System.Threading.Tasks;

using Lease.Infrastructure.Lease;
using Lease.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lease.Microservice.Controllers
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

        [Route("AddLeaseOrderLine")]
        [HttpPost]
        public Task<IActionResult> Post(LeaseOrderCommands.V1.AddLeaseOrderLineToLeaseOrder request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("address")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.UpdateAddress request)
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

        [Route("leaseorderline")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.UpdateLeaseOrderLine request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);


        [Route("lease")]
        [HttpDelete]
        public Task<IActionResult> Delete(LeaseOrderCommands.V1.DeleteLease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);


        [Route("leaseOrderLine")]
        [HttpDelete]
        public Task<IActionResult> Delete(LeaseOrderCommands.V1.DeleteLeaseOrderLine request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}