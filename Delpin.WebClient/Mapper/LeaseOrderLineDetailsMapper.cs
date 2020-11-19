using Delpin.Shared.LeaseModels;
using Delpin.WebClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.Mapper
{
    public class LeaseOrderLineDetailsMapper
    {
        public static LeaseViewModel.LeaseOrderLineDetails Map(LeaseDto.LeaseOrderLineDetails dto)
        {
            if (dto == null)
            { return null; }
            return new LeaseViewModel.LeaseOrderLineDetails
            {
                LeaseOrderLineId = dto.LeaseOrderLineId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsReturned = dto.IsReturned,
                RessourceName = dto.RessourceName,
                RessourcePrice = dto.RessourcePrice,
                Quantity = dto.Quantity,
                LineTotalPrice = dto.LineTotalPrice,
                
            };
        }

        public static IEnumerable<LeaseViewModel.LeaseOrderLineDetails> Map(IEnumerable<LeaseDto.LeaseOrderLineDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<LeaseDto.LeaseOrderLineDetails> Map(IEnumerable<LeaseViewModel.LeaseOrderLineDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static LeaseDto.LeaseOrderLineDetails Map(LeaseViewModel.LeaseOrderLineDetails model)
        {
            if (model == null)
            { return null; }
            return new LeaseDto.LeaseOrderLineDetails
            {
                LeaseOrderLineId = model.LeaseOrderLineId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsReturned = model.IsReturned,
                RessourceName = model.RessourceName,
                RessourcePrice = model.RessourcePrice,
                Quantity = model.Quantity,
                LineTotalPrice = model.LineTotalPrice,

            };
        }
    }
}

