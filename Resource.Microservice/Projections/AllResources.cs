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
    public class AllResources :IProjection
    {
        private readonly List<Resources> _items;
        public AllResources(
            List<Resources> items)
        {
            _items = items;
        }

        public Task Project(object @event)
        {
            switch (@event)
            {
                case ResourceRegistered e:
                    _items.Add(
                        new Resources
                        {
                            ResourceNo = e.ResourceNo,
                            ResourceName = e.ResourceName,
                            ResourcePrice = e.ResourcePrice
                        }
                    );
                    break;

                case ResourceNameUpdated e:
                    UpdateResource(ad => ad.ResourceName = e.ResourceName);
                    break;

                case ResourceNoUpdated e:
                    UpdateResource(ad => ad.ResourceNo = e.ResourceNo);
                    break;

                case ResourcePriceUpdated e:
                    UpdateResource(ad => ad.ResourcePrice = e.ResourcePrice);
                    break;      
            }

            return Task.CompletedTask;

        }

        private void UpdateResource(Action<Resources> update)
        {
            var item = _items.FirstOrDefault(x => x.IsDeleted == false);
            if (item == null) return;

            update(item);
        }

        private void UpdateMultipleItems(
           Func<Resources, bool> query,
           Action<Resources> update
        )
        {
            foreach (var item in _items.Where(query))
                update(item);
        }
    }
}
