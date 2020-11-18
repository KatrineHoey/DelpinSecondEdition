using System.Threading.Tasks;
using Delpin.Shared.LeaseModels;
using Lease.Application;
using Lease.Infrastructure.Shared;
using Lease.Intrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lease.Microservice.Lease.Command
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
        public Task<IActionResult> Post(LeaseOrderLineCommands.V1.AddLeaseOrderLineToLeaseOrder request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);


        [Route("adresse")]
        [HttpPut]
        public Task<IActionResult> Put(LeaseOrderCommands.V1.UpdateAddress request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

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
        public Task<IActionResult> Put(LeaseOrderLineCommands.V1.UpdateLeaseOrderLine request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);


        [Route("lease")]
        [HttpDelete]
        public Task<IActionResult> Delete(LeaseOrderCommands.V1.DeleteLease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);


        [Route("leaseOrderLine")]
        [HttpDelete]
        public Task<IActionResult> Delete(LeaseOrderLineCommands.V1.DeleteLeaseOrderLine request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}