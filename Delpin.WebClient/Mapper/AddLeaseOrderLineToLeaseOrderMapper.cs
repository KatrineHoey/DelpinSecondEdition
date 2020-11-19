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
                RessourceId = dto.RessourceId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsReturned = dto.IsReturned,
                RessourceName = dto.RessourceName,
                RessourcePrice = dto.RessourcePrice,
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
                RessourceId = model.RessourceId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsReturned = model.IsReturned,
                RessourceName = model.RessourceName,
                RessourcePrice = model.RessourcePrice,
                Quantity = model.Quantity,

            };
        }
    }
}
