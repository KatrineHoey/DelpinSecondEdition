using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delpin.Framework;
using static Resource.Domain.Shared.Events;
using static Resource.Microservice.Projections.ResourceUpcastedEvents;
using static Resource.Microservice.Projections.ReadModels;
using System;

namespace Resource.Microservice.Projections
{
    public class ResourceDetailsProjection :IProjection
    {
        private readonly List<ResourceDetails> _items;

        public ResourceDetailsProjection(
            List<ResourceDetails> items)
        {
            _items = items;
        }

        public Task Project(object @event)
        {
            switch(@event)
            {
                case ResourceRegistered e:
                    _items.Add(
                        new ResourceDetails
                        {
                            ResourceId = e.ResourceId,
                            ResourceNo = e.ResourceNo,
                            ResourceName = e.ResourceName,
                            ResourcePrice = e.ResourcePrice
                        }
                    );
                    break;

                case ResourceNameUpdated e:
                    UpdateItem(e.ResourceId, ad => ad.ResourceName = e.ResourceName);
                    break;

                case ResourceNoUpdated e:
                    UpdateItem(e.ResourceId, ad => ad.ResourceNo = e.ResourceNo);
                    break;

                case ResourcePriceUpdated e:
                    UpdateItem(e.ResourceId, ad => ad.ResourcePrice = e.ResourcePrice);
                    break;
                case ResourceDeleted e:
                    UpdateItem(e.ResourceId, ad => ad.IsDeleted = e.IsDeleted);
                    break;                    
            }

            return Task.CompletedTask;
           
        }

        private void UpdateItem(Guid id, Action<ResourceDetails> update)
        {
            var item = _items.FirstOrDefault(x => x.ResourceId == id);
            if (item == null) return;

            update(item);
        }

        private void UpdateMultipleItems(
           Func<ResourceDetails, bool> query,
           Action<ResourceDetails> update
        )
        {
            foreach (var item in _items.Where(query))
                update(item);
        }
    }
}
