using Delpin.Shared.CustomerModels;
using Delpin.WebClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.Mapper
{
    public class ActiveCustomerSearchListItemMapper
    {
        public static CustomerViewModel.ActiveCustomerSearchListItem Map(ReadModelsDto.ActiveCustomerSearchListItem dto)
        {
            if (dto == null)
            { return null; }
            return new CustomerViewModel.ActiveCustomerSearchListItem
            {
                CustomerId = dto.CustomerId,
                FullName = dto.FullName,
                PhoneNo = dto.PhoneNo,
                City = dto.City
            };
        }

        public static IEnumerable<CustomerViewModel.ActiveCustomerSearchListItem> Map(IEnumerable<ReadModelsDto.ActiveCustomerSearchListItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<ReadModelsDto.ActiveCustomerSearchListItem> Map(IEnumerable<CustomerViewModel.ActiveCustomerSearchListItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ReadModelsDto.ActiveCustomerSearchListItem Map(CustomerViewModel.ActiveCustomerSearchListItem model)
        {
            if (model == null)
            { return null; }
            return new ReadModelsDto.ActiveCustomerSearchListItem
            {
                CustomerId = model.CustomerId,
                FullName = model.FullName,
                PhoneNo = model.PhoneNo,
                City = model.City
            };
        }
    }
}
