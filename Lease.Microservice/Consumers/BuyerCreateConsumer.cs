using Delpin.Shared.CustomerModels;
using Lease.Application;
using Lease.Intrastructure;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delpin.Shared.LeaseModels;

namespace Lease.Microservice.Consumers
{
    public class BuyerCreateConsumer : IConsumer<CustomerCommandsDto.V1.RegisterCustomer>
    {
        private readonly LeaseApplicationService _applicationService;
        public BuyerCreateConsumer(LeaseApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task Consume(ConsumeContext<CustomerCommandsDto.V1.RegisterCustomer> context)
        {
            var data = context.Message;

            BuyerCommands.V1.CreateBuyer buyer = new BuyerCommands.V1.CreateBuyer();
            buyer.BuyerId = data.CustomerId;
            buyer.BuyerName = data.FullName;
            await _applicationService.Handle(buyer);
        }
    }


    public class BuyerUpdateNameConsumer : IConsumer<CustomerCommandsDto.V1.UpdateCustomerFullName>
    {
        private readonly LeaseApplicationService _applicationService;
        public BuyerUpdateNameConsumer(LeaseApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task Consume(ConsumeContext<CustomerCommandsDto.V1.UpdateCustomerFullName> context)
        {
            var data = context.Message;

            BuyerCommands.V1.UpdateBuyer buyer = new BuyerCommands.V1.UpdateBuyer();
            buyer.BuyerId = data.CustomerId;
            buyer.BuyerName = data.FullName;
            await _applicationService.Handle(buyer);
        }
    }
}
