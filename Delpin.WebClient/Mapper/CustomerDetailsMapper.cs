using Delpin.Shared.CustomerModels;
using Delpin.WebClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Delpin.WebClient.Mapper
{
    public class CustomerDetailsMapper
    {
        public static CustomerViewModel.CustomerDetails Map(CustomerDto.CustomerDetails dto)
        {
            if (dto == null)
            { return null; }
            return new CustomerViewModel.CustomerDetails
            {
                CustomerId = dto.CustomerId,
                FullName = dto.FullName,
                PhoneNo = dto.PhoneNo,
                Email = dto.Email,
                CustomerType = (Enum.CustomerTypeEnum)dto.CustomerType,
                City = dto.City,
                Street = dto.Street,
                ZipCode = dto.ZipCode,
                IsDeleted = dto.IsDeleted
            };
        }

        public static IEnumerable<CustomerViewModel.CustomerDetails> Map(IEnumerable<CustomerDto.CustomerDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<CustomerDto.CustomerDetails> Map(IEnumerable<CustomerViewModel.CustomerDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static CustomerDto.CustomerDetails Map(CustomerViewModel.CustomerDetails model)
        {
            if (model == null)
            { return null; }
            return new CustomerDto.CustomerDetails
            {
                CustomerId = model.CustomerId,
                FullName = model.FullName,
                PhoneNo = model.PhoneNo,
                Email = model.Email,
                CustomerType = (Delpin.Shared.Enum.CustomerTypeEnum)model.CustomerType,
                City = model.City,
                Street = model.Street,
                ZipCode = model.ZipCode,
                IsDeleted = model.IsDeleted
            };
        }
    }
}
