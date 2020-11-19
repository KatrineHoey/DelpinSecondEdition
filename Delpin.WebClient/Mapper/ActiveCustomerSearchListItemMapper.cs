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
        public static CustomerViewModel.ActiveCustomerSearchListItem Map(CustomerDto.ActiveCustomerSearchListItem dto)
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

        public static IEnumerable<CustomerViewModel.ActiveCustomerSearchListItem> Map(IEnumerable<CustomerDto.ActiveCustomerSearchListItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<CustomerDto.ActiveCustomerSearchListItem> Map(IEnumerable<CustomerViewModel.ActiveCustomerSearchListItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static CustomerDto.ActiveCustomerSearchListItem Map(CustomerViewModel.ActiveCustomerSearchListItem model)
        {
            if (model == null)
            { return null; }
            return new CustomerDto.ActiveCustomerSearchListItem
            {
                CustomerId = model.CustomerId,
                FullName = model.FullName,
                PhoneNo = model.PhoneNo,
                City = model.City
            };
        }
    }
}
