﻿using Delpin.Shared.LeaseModels;
using Delpin.WebClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.Mapper
{
    public class LeaseOrderLineDetailsMapper
    {
        public static LeaseViewModel.LeaseOrderLineDetails Map(LeaseReadModelsDto.LeaseOrderLineDetails dto)
        {
            if (dto == null)
            { return null; }
            return new LeaseViewModel.LeaseOrderLineDetails
            {
                LeaseOrderLineId = dto.LeaseOrderLineId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsReturned = dto.IsReturned,
                ResourceName = dto.ResourceName,
                ResourcePrice = dto.ResourcePrice,
                Quantity = dto.Quantity,
                LineTotalPrice = dto.LineTotalPrice,
                
            };
        }

        public static IEnumerable<LeaseViewModel.LeaseOrderLineDetails> Map(IEnumerable<LeaseReadModelsDto.LeaseOrderLineDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<LeaseReadModelsDto.LeaseOrderLineDetails> Map(IEnumerable<LeaseViewModel.LeaseOrderLineDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static LeaseReadModelsDto.LeaseOrderLineDetails Map(LeaseViewModel.LeaseOrderLineDetails model)
        {
            if (model == null)
            { return null; }
            return new LeaseReadModelsDto.LeaseOrderLineDetails
            {
                LeaseOrderLineId = model.LeaseOrderLineId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsReturned = model.IsReturned,
                ResourceName = model.ResourceName,
                ResourcePrice = model.ResourcePrice,
                Quantity = model.Quantity,
                LineTotalPrice = model.LineTotalPrice,
                

            };
        }
    }
}

