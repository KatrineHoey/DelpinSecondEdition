using Delpin.Shared.LeaseModels;
using Delpin.WebClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.Mapper
{
    public class LeaseOrderDetailsMapper
    {
        public static LeaseViewModel.LeaseOrderDetails Map(LeaseReadModelsDto.LeaseOrderDetails dto)
        {
            if (dto == null)
            { return null; }
            return new LeaseViewModel.LeaseOrderDetails
            {
                LeaseId = dto.LeaseId,
                BuyerId = dto.BuyerId,
                BuyerName = dto.BuyerName,
                Street = dto.Street,
                ZipCode = dto.ZipCode,
                City = dto.City,
                DateCreated = dto.DateCreated,
                IsDeleted = dto.IsDeleted,
                IsDelivery = dto.IsDelivery,
                IsPaid = dto.IsPaid,
                TotalPrice = dto.TotalPrice,
                //leaseOrderLines = LeaseOrderLineDetailsMapper.Map(dto.leaseOrderLines)
                
            };
        }

        public static IEnumerable<LeaseViewModel.LeaseOrderDetails> Map(IEnumerable<LeaseReadModelsDto.LeaseOrderDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<LeaseReadModelsDto.LeaseOrderDetails> Map(IEnumerable<LeaseViewModel.LeaseOrderDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static LeaseReadModelsDto.LeaseOrderDetails Map(LeaseViewModel.LeaseOrderDetails model)
        {
            if (model == null)
            { return null; }
            return new LeaseReadModelsDto.LeaseOrderDetails
            {
                LeaseId = model.LeaseId,
                BuyerId = model.BuyerId,
                BuyerName = model.BuyerName,
                Street = model.Street,
                ZipCode = model.ZipCode,
                City = model.City,
                DateCreated = model.DateCreated,
                IsDeleted = model.IsDeleted,
                IsDelivery = model.IsDelivery,
                IsPaid = model.IsPaid,
                TotalPrice = model.TotalPrice,
                //leaseOrderLines = LeaseOrderLineDetailsMapper.Map(model.leaseOrderLines)

            };
        }
    }
}
