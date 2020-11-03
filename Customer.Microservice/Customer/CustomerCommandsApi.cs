using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Customer.Microservice.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Microservice.Customer
{
    [Route("/customer")]
    public class CustomerCommandsApi : Controller
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<CustomerCommandsApi>();
        private readonly CustomerApplicationService _applicationService;

        public CustomerCommandsApi(CustomerApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public Task<IActionResult> Post(Commands.V1.RegisterCustomer request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

        [Route("fullname")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateCustomerFullName request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

        [Route("adresse")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateCustomerAdresse request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

        [Route("phone")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateCustomerPhoneNo request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

        [Route("email")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.UpdateCustomerEmail request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

        [Route("customertype")]
        [HttpPut]
        public Task<IActionResult> Put(Commands.V1.ChangeCustomerType request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

        [HttpDelete]
        public Task<IActionResult> Put(Commands.V1.DeleteCustomer request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }
    }
}
