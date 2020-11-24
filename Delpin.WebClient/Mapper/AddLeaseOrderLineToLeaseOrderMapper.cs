using Delpin.Shared.LeaseModels;
using Delpin.WebClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.Mapper
{
    public class AddLeaseOrderLineToLeaseOrderMapper
    {
        public static LeaseViewModel.AddLeaseOrderLineToLeaseOrder Map(LeaseDto.AddLeaseOrderLineToLeaseOrder dto)
        {
            if (dto == null)
            { return null; }
            return new LeaseViewModel.AddLeaseOrderLineToLeaseOrder
            {
                LeaseId = dto.LeaseId,
                LeaseOrderLineId = dto.LeaseOrderLineId,
                ResourceId = dto.ResourceId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsReturned = dto.IsReturned,
                ResourceName = dto.ResourceName,
                ResourcePrice = dto.ResourcePrice,
                Quantity = dto.Quantity,
            };
        }

        public static IEnumerable<LeaseViewModel.AddLeaseOrderLineToLeaseOrder> Map(IEnumerable<LeaseDto.AddLeaseOrderLineToLeaseOrder> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<LeaseDto.AddLeaseOrderLineToLeaseOrder> Map(IEnumerable<LeaseViewModel.AddLeaseOrderLineToLeaseOrder> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static LeaseDto.AddLeaseOrderLineToLeaseOrder Map(LeaseViewModel.AddLeaseOrderLineToLeaseOrder model)
        {
            if (model == null)
            { return null; }
            return new LeaseDto.AddLeaseOrderLineToLeaseOrder
            {
                LeaseId = model.LeaseId,
                LeaseOrderLineId = model.LeaseOrderLineId,
                ResourceId = model.ResourceId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsReturned = model.IsReturned,
                ResourceName = model.ResourceName,
                ResourcePrice = model.ResourcePrice,
                Quantity = model.Quantity,

            };
        }
    }
}
