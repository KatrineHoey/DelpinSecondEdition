using Delpin.Shared.ResourceModels;
using Delpin.WebClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.Mapper
{
    public class ActiveResourceSearchListItemMapper
    {
        public static ResourceViewModel.ActiveResourceSearchListItem Map(ResourceDto.ActiveResourceSearchListItem dto)
        {
            if (dto == null)
            { return null; }
            return new ResourceViewModel.ActiveResourceSearchListItem
            {
                ResourceId = dto.ResourceId,
                ResourceName = dto.ResourceName,
                ResourceNo = dto.ResourceNo,
                ResourcePrice = dto.ResourcePrice
            };
        }

        public static IEnumerable<ResourceViewModel.ActiveResourceSearchListItem> Map(IEnumerable<ResourceDto.ActiveResourceSearchListItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<ResourceDto.ActiveResourceSearchListItem> Map(IEnumerable<ResourceViewModel.ActiveResourceSearchListItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ResourceDto.ActiveResourceSearchListItem Map(ResourceViewModel.ActiveResourceSearchListItem model)
        {
            if (model == null)
            { return null; }
            return new ResourceDto.ActiveResourceSearchListItem
            {
                ResourceId = model.ResourceId,
                ResourceName = model.ResourceName,
                ResourceNo = model.ResourceNo,
                ResourcePrice = model.ResourcePrice
            };
        }
    }
}
