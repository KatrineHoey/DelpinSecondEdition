using System;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Delpin.Framework;
using Resource.Infrastructure;
using static Resource.Domain.Shared.Events;
using static Resource.Microservice.Projections.ResourceUpcastedEvents;

namespace Resource.Microservice.Projections
{
    public class ResourceUpcasters : IProjection
    {
        private readonly IEventStoreConnection _eventStoreConnection;
        private const string StreamName = "UpcastedResourceEvents";

        public ResourceUpcasters(IEventStoreConnection eventStoreConnection)
        {
            _eventStoreConnection = eventStoreConnection;
        }

        public async Task Project(object @event)
        {
            switch (@event)
            {
                case ResourceRegistered e:
                    var newEvent = new V1.ResourceRegistered
                    {
                        ResourceId = e.ResourceId,
                        ResourceNo = e.ResourceNo,
                        ResourceName = e.ResourceName,
                        ResourcePrice = e.ResourcePrice
                    };
                    await _eventStoreConnection.AppendEvents(
                        StreamName,
                        ExpectedVersion.Any,
                        newEvent);
                    break;
            }
        }
    }

    public static class ResourceUpcastedEvents
    {
        public static class V1
        {
            public class ResourceRegistered
            {
                public Guid ResourceId { get; set; }
                public int ResourceNo { get; set; }
                public string ResourceName { get; set; }
                public decimal ResourcePrice { get; set; }
            }            
        }
    }
}
