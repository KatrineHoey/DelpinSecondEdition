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

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public bool IsReturned { get; private set; }

        public string RessourceName { get; private set; }

        public int RessourcePrice { get; private set; }

        public int Quantity { get; private set; }

        public int LineTotalPrice { get; private set; }

        public Guid LeaseId { get; private set; }

        public LeaseOrder LeaseOrder { get; private set; }

        public LeaseOrderLine(Guid leaseOrderLineId, Guid leaseOrderId, DateTime startDate, DateTime endDate, bool isReturned, string ressourceName, int ressourcePrice, int quantity)
        {
            Apply(new LeaseOrderLineEvents.LeaseOrderLineAddedToLeaseOrder
            {
                LeaseOrderLineId = leaseOrderLineId,
                LeaseOrderId = leaseOrderId,
                StartDate = startDate,
                EndDate = endDate,
                IsReturned = isReturned,
                RessourceName = ressourceName,
                RessourcePrice = ressourcePrice,
                Quantity = quantity
            });
        }

        public void UpdateLeaseOrderLine(StartDate startDate, EndDate endDate, IsReturned isReturned, RessourceName ressourceName, RessourcePrice ressourcePrice, Quantity quantity)
        {
            Apply(new LeaseOrderLineEvents.LeaseOrderLineUpdated
            {
                LeaseOrderLineId = LeaseOrderLineId,
                StartDate = startDate,
                EndDate = endDate,
                IsReturned = isReturned,
                RessourceName = ressourceName,
                RessourcePrice = ressourcePrice,
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
                    LeaseId = e.LeaseOrderId;
                    Id = new LeaseOrderLineId(e.LeaseOrderLineId);                    
                    StartDate = new StartDate( e.StartDate);
                    EndDate = new EndDate( e.EndDate);
                    IsReturned = new IsReturned( e.IsReturned);
                    RessourceName = new RessourceName( e.RessourceName);
                    RessourcePrice = new RessourcePrice( e.RessourcePrice);
                    Quantity = new Quantity( e.Quantity);
                    break;

                case LeaseOrderLineEvents.LeaseOrderLineUpdated e:
                    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    StartDate = new StartDate(e.StartDate);
                    EndDate = new EndDate(e.EndDate);
                    IsReturned = new IsReturned(e.IsReturned);
                    RessourceName = new RessourceName(e.RessourceName);
                    RessourcePrice = new RessourcePrice(e.RessourcePrice);
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
