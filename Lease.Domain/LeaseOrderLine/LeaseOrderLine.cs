using Delpin.Framework;
using Lease.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lease.Domain
{
    public class LeaseOrderLine : Entity<LeaseOrderLineId>
    {
        // Properties to handle the persistence
        public Guid LeaseOrderLineId { get; private set;}

        protected LeaseOrderLine() { }
        // Entity state properties

        public StartDate StartDate { get; private set; }

        public EndDate EndDate { get; private set; }

        public IsReturned IsReturned { get; private set; }

        public ResourceName ResourceName { get; private set; }

        public ResourcePrice ResourcePrice { get; private set; }

        public Quantity Quantity { get; private set; }

        public LineTotalPrice LineTotalPrice { get; private set; }

        public Guid LeaseId { get; private set; }

        public ResourceId ResourceId { get; private set; }

        public LeaseOrder LeaseOrder { get; private set; }

        public LeaseOrderLine(LeaseOrderLineId leaseOrderLineId, LeaseOrderId leaseOrderId,ResourceId ResourceId, StartDate startDate, EndDate endDate, IsReturned isReturned, ResourceName ResourceName, ResourcePrice ResourcePrice, Quantity quantity)
        {
            Apply(new LeaseOrderLineEvents.LeaseOrderLineAddedToLeaseOrder
            {
                LeaseOrderLineId = leaseOrderLineId,
                LeaseOrderId = leaseOrderId,
                ResourceId = ResourceId,
                StartDate = startDate,
                EndDate = endDate,
                IsReturned = isReturned,
                ResourceName = ResourceName,
                ResourcePrice = ResourcePrice,
                Quantity = quantity
            });
        }

        public void UpdateLeaseOrderLine(StartDate startDate, EndDate endDate, IsReturned isReturned, ResourceName ResourceName, ResourcePrice ResourcePrice, Quantity quantity)
        {
            Apply(new LeaseOrderLineEvents.LeaseOrderLineUpdated
            {
                LeaseOrderLineId = LeaseOrderLineId,
                StartDate = startDate,
                EndDate = endDate,
                IsReturned = isReturned,
                ResourceName = ResourceName,
                ResourcePrice = ResourcePrice,
                Quantity = quantity,
            });
        }

        public void LeaseOrderLineDeleted()
        {
            Apply(new LeaseOrderLineEvents.LeaseOrderLineDeleted
            {
                LeaseOrderLineId = LeaseOrderLineId
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {

                case LeaseOrderLineEvents.LeaseOrderLineAddedToLeaseOrder e:
                    LeaseId = new LeaseOrderId(e.LeaseOrderId);
                    ResourceId = new ResourceId(e.ResourceId);
                    Id = new LeaseOrderLineId(e.LeaseOrderLineId);                    
                    StartDate = new StartDate( e.StartDate);
                    EndDate = new EndDate( e.EndDate);
                    IsReturned = new IsReturned( e.IsReturned);
                    ResourceName = new ResourceName( e.ResourceName);
                    ResourcePrice = new ResourcePrice( e.ResourcePrice);
                    Quantity = new Quantity( e.Quantity);
                    break;

                case LeaseOrderLineEvents.LeaseOrderLineUpdated e:
                    StartDate = new StartDate(e.StartDate);
                    EndDate = new EndDate(e.EndDate);
                    IsReturned = new IsReturned(e.IsReturned);
                    ResourceName = new ResourceName(e.ResourceName);
                    ResourcePrice = new ResourcePrice(e.ResourcePrice);
                    Quantity = new Quantity(e.Quantity);
                    break;


                case LeaseOrderLineEvents.LeaseOrderLineDeleted e:
                    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    break;
            }
        }

        public LeaseOrderLine(Action<object> applier) : base(applier)
        {
        }
    }
}
