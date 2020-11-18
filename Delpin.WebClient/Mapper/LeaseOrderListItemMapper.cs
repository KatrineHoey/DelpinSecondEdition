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
        public static LeaseViewModel.LeaseOrderListItem Map(LeaseDto.LeaseOrderListItem dto)
        {
            if (dto == null)
            { return null; }
            return new LeaseViewModel.LeaseOrderListItem
            {
                LeaseId = dto.LeaseId,
                DateCreated = dto.DateCreated,
                CustomerName = dto.CustomerName,
                IsPaid = dto.IsPaid
            };
        }

        public static IEnumerable<LeaseViewModel.LeaseOrderListItem> Map(IEnumerable<LeaseDto.LeaseOrderListItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<LeaseDto.LeaseOrderListItem> Map(IEnumerable<LeaseViewModel.LeaseOrderListItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static LeaseDto.LeaseOrderListItem Map(LeaseViewModel.LeaseOrderListItem model)
        {
            if (model == null)
            { return null; }
            return new LeaseDto.LeaseOrderListItem
            {
                LeaseId = model.LeaseId,
                DateCreated = model.DateCreated,
                CustomerName = model.CustomerName,
                IsPaid = model.IsPaid
            };
        }
    }
}

