using Delpin.Shared.ResourceModels;
using Delpin.WebClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.Mapper
{
    public class ResourceDetailsMapper
    {
        public static ResourceViewModel.ResourceDetails Map(ResourceDto.ResourceDetails dto)
        {
            if (dto == null)
            { return null; }
            return new ResourceViewModel.ResourceDetails
            {
                ResourceId = dto.ResourceId,
                ResourceName = dto.ResourceName,
                ResourceNo = dto.ResourceNo,
                ResourcePrice = dto.ResourcePrice,
                IsDeleted = dto.IsDeleted,
            };
        }

        public static IEnumerable<ResourceViewModel.ResourceDetails> Map(IEnumerable<ResourceDto.ResourceDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<ResourceDto.ResourceDetails> Map(IEnumerable<ResourceViewModel.ResourceDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ResourceDto.ResourceDetails Map(ResourceViewModel.ResourceDetails model)
        {
            if (model == null)
            { return null; }
            return new ResourceDto.ResourceDetails
            {
                ResourceId = model.ResourceId,
                ResourceName = model.ResourceName,
                ResourceNo = model.ResourceNo,
                ResourcePrice = model.ResourcePrice,
                IsDeleted = model.IsDeleted,
            };
        }
    }
}
