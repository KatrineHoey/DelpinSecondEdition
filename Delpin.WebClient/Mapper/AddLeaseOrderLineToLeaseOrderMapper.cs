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
        public static LeaseViewModel.AddLeaseOrderLineToLeaseOrder Map(LeaseReadModelsDto.LeaseOrderLineDetails dto)
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

        public static IEnumerable<LeaseViewModel.AddLeaseOrderLineToLeaseOrder> Map(IEnumerable<LeaseReadModelsDto.LeaseOrderLineDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<LeaseReadModelsDto.LeaseOrderLineDetails> Map(IEnumerable<LeaseViewModel.AddLeaseOrderLineToLeaseOrder> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static LeaseReadModelsDto.LeaseOrderLineDetails Map(LeaseViewModel.AddLeaseOrderLineToLeaseOrder model)
        {
            if (model == null)
            { return null; }
            return new LeaseReadModelsDto.LeaseOrderLineDetails
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
