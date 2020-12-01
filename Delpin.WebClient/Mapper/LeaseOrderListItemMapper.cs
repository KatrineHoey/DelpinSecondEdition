using Delpin.Shared.LeaseModels;
using Delpin.WebClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.Mapper
{
    public class LeaseOrderListItemMapper
    {
        public static LeaseViewModel.LeaseOrderListItem Map(LeaseReadModelsDto.LeaseOrderListItem dto)
        {
            if (dto == null)
            { return null; }
            return new LeaseViewModel.LeaseOrderListItem
            {
                LeaseId = dto.LeaseId,
                DateCreated = dto.DateCreated,
                BuyerName = dto.BuyerName,
                IsPaid = dto.IsPaid
            };
        }

        public static IEnumerable<LeaseViewModel.LeaseOrderListItem> Map(IEnumerable<LeaseReadModelsDto.LeaseOrderListItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<LeaseReadModelsDto.LeaseOrderListItem> Map(IEnumerable<LeaseViewModel.LeaseOrderListItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static LeaseReadModelsDto.LeaseOrderListItem Map(LeaseViewModel.LeaseOrderListItem model)
        {
            if (model == null)
            { return null; }
            return new LeaseReadModelsDto.LeaseOrderListItem
            {
                LeaseId = model.LeaseId,
                DateCreated = model.DateCreated,
                BuyerName = model.BuyerName,
                IsPaid = model.IsPaid
            };
        }
    }
}

