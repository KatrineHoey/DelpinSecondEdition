using Delpin.Framework;
using Resource.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Resource.Domain
{
    public class Resource : AggregateRoot<ResourceId>
    {
        // Properties to handle the persistence
        //public Guid resourceId { get; private set; }


        // Aggregate state properties
        public ResourceName ResourceName { get; set; }
        public ResourceNo ResourceNo { get; set; }
        public ResourcePrice ResourcePrice { get; set; }
        public IsDeleted IsDeleted { get; set; }
        public ResourceState State { get; set; }

        // Satisfy the serialization requirements
        protected Resource() { }

        public Resource(ResourceId resourceId, ResourceName resourceName, ResourceNo resourceNo, ResourcePrice resourcePrice, IsDeleted isDeleted)
        {
            Apply(new Events.ResourceRegistered
            {
                ResourceId = resourceId,
                ResourceName = resourceName,
                ResourceNo = resourceNo,
                ResourcePrice = resourcePrice,
                //IsDeleted = isDeleted
            });
        }

        public Resource(ResourceId resourceId)
        {
            Id = resourceId;
        }
       
        public void UpdateName(ResourceName resourceName)
        {
            Apply(new Events.ResourceNameUpdated
            {
                ResourceId = Id,
                ResourceName = resourceName
            });
        }

        public void UpdateResourceNo(ResourceNo resourceNo)
        {
            Apply(new Events.ResourceNoUpdated
            {
                ResourceId = Id,
                ResourceNo = resourceNo
            }); ;
        }

        public void UpdateResourcePrice(ResourcePrice resourcePrice)
        {
            Apply(new Events.ResourcePriceUpdated
            {
                ResourceId = Id,
                ResourcePrice = resourcePrice
            }) ;
        }

        public void ResourceDeleted(IsDeleted isDeleted)
        {
            Apply(new Events.ResourceDeleted
            {
                ResourceId = Id,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.ResourceRegistered e:
                    Id = new ResourceId(e.ResourceId);
                    ResourceName = new ResourceName(e.ResourceName);
                    ResourceNo = new ResourceNo(e.ResourceNo);
                    ResourcePrice = new ResourcePrice(e.ResourcePrice);
                    //IsDeleted = new IsDeleted(e.IsDeleted);
                    break;
                case Events.ResourceDeleted e:
                    Id = new ResourceId(e.ResourceId);
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    break;
                case Events.ResourceNameUpdated e:
                    Id = new ResourceId(e.ResourceId);
                    ResourceName = new ResourceName(e.ResourceName);
                    break;
                case Events.ResourceNoUpdated e:
                    Id = new ResourceId(e.ResourceId);
                    ResourceNo = new ResourceNo(e.ResourceNo);
                    break;
                case Events.ResourcePriceUpdated e:
                    Id = new ResourceId(e.ResourceId);
                    ResourcePrice = new ResourcePrice(e.ResourcePrice);
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            bool valid =
                Id != null &&
                (State switch
                {
                    ResourceState.PendingReview =>
                        ResourceName != null &&
                        ResourceNo != null &&
                        ResourcePrice != null &&
                        IsDeleted != null,

                    ResourceState.Active =>
                        ResourceName != null &&
                        ResourceNo != null &&
                        ResourcePrice != null &&
                        IsDeleted != null,
                    _ => true
                });
            if (!valid)
            {
                throw new DomainExceptions.InvalidEntityState(this, $"Post-checks failed in state {State}");
            }
        }

        public enum ResourceState
        {
            PendingReview, 
            Active, 
            Inactive, 
            MarkedAsSold
        }
    }
}
