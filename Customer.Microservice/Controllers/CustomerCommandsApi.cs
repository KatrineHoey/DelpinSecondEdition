using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Mvc;
using Delpin.Shared.CustomerModels;
using MassTransit;
using Customer.Infrastructure.Shared;
using Customer.Application.Command;

namespace Customer.Microservice.Controllers
{
    [Route("/customer")]
    public class CustomerCommandsApi : Controller
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<CustomerCommandsApi>();
        private readonly CustomerApplicationService _applicationService;
        private readonly IBus _bus;

        public CustomerCommandsApi(CustomerApplicationService applicationService, IBus bus)
        {
            _applicationService = applicationService;
            _bus = bus;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CustomerCommandsDto.V1.RegisterCustomer request)
        {
            var response =  RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

            if (!response.IsFaulted)
            {
                Uri uri = new Uri("rabbitmq://localhost/CustomerQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }

            return (ActionResult)await response;
        }

        [Route("fullname")]
        [HttpPut]
        public async Task<ActionResult> Put(CustomerCommandsDto.V1.UpdateCustomerFullName request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri("rabbitmq://localhost/CustomerUpdateQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }

        [Route("adresse")]
        [HttpPut]
        public Task<IActionResult> Put(CustomerCommandsDto.V1.UpdateCustomerAdresse request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

        [Route("phone")]
        [HttpPut]
        public Task<IActionResult> Put(CustomerCommandsDto.V1.UpdateCustomerPhoneNo request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

        [Route("email")]
        [HttpPut]
        public Task<IActionResult> Put(CustomerCommandsDto.V1.UpdateCustomerEmail request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

        [Route("customertype")]
        [HttpPut]
        public Task<IActionResult> Put(CustomerCommandsDto.V1.ChangeCustomerType request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }

        [HttpDelete]
        public Task<IActionResult> Put(CustomerCommandsDto.V1.DeleteCustomer request)
        {
            return RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
        }
    }
}
