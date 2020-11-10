using Delpin.Framework;
using Lease.Domain.Shared;
using Lease.Domain.Shared.Events;
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

        //public LeaseOrderLineState State { get; private set; }

        public LeaseOrderLine(Guid leaseOrderLineId, Guid leaseOrderId, DateTime startDate, DateTime endDate, bool isReturned, string ressourceName, int ressourcePrice, int quantity)
        {
            Apply(new LeaseOrderEvents.LeaseOrderLineAddedToLeaseOrder
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
            Apply(new LeaseOrderEvents.LeaseOrderLineUpdated
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

        protected override void When(object @event)
        {
            switch (@event)
            {

                case LeaseOrderEvents.LeaseOrderLineAddedToLeaseOrder e:
                    LeaseId = e.LeaseOrderId;
                    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    
                    StartDate = new StartDate( e.StartDate);
                    EndDate = new EndDate( e.EndDate);
                    IsReturned = new IsReturned( e.IsReturned);
                    RessourceName = new RessourceName( e.RessourceName);
                    RessourcePrice = new RessourcePrice( e.RessourcePrice);
                    Quantity = new Quantity( e.Quantity);
                    break;

                    //case LeaseOrderLineEvents.UpdateStartDate e:
                    //    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    //    StartDate = new StartDate(e.StartDate);
                    //    break;

                    //case LeaseOrderLineEvents.UpdateEndDate e:
                    //    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    //    EndDate = new EndDate(e.EndDate);
                    //    break;

                    //case LeaseOrderLineEvents.UpdateIsReturned e:
                    //    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    //    IsReturned = new IsReturned(e.IsReturned);
                    //    break;

                    //case LeaseOrderLineEvents.UpdateRessourceName e:
                    //    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    //    RessourceName = new RessourceName(e.RessourceName);
                    //    break;

                    //case LeaseOrderLineEvents.UpdateRessourcePrice e:
                    //    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    //    RessourcePrice = new RessourcePrice(e.RessourcePrice);
                    //    break;

                    //case LeaseOrderLineEvents.UpdateQuantity e:
                    //    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    //    Quantity = new Quantity(e.Quantity);
                    //    break;

                    //case LeaseOrderLineEvents.UpdateLineTotalPrice e:
                    //    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    //    LineTotalPrice = new LineTotalPrice(e.LineTotalPrice);
                    //    break;
            }
        }

        public LeaseOrderLine(Action<object> applier) : base(applier)
        {
        }


        //protected override void EnsureValidState()
        //{
        //    var valid =
        //        Id != null &&
        //        (State switch
        //        {
        //            LeaseOrderLineState.PendingReview =>
        //                 StartDate != null
        //                && EndDate != null
        //                && IsReturned != null
        //                && RessourceName != null
        //                && RessourcePrice != null
        //                && Quantity != null
        //                && LineTotalPrice != null,


        //            LeaseOrderLineState.Active =>
        //                 StartDate != null
        //                && EndDate != null
        //                && IsReturned != null
        //                && RessourceName != null
        //                && RessourcePrice != null
        //                && Quantity != null
        //                && LineTotalPrice != null,


        //            _ => true
        //        });

        //    if (!valid)
        //        throw new DomainExceptions.InvalidEntityState(this, $"Post-checks failed in state {State}");
        //}

        //public enum LeaseOrderLineState
        //{
        //    PendingReview = 1,
        //    Active = 2,
        //    Inactive = 3,
        //    MarkedAsSold = 4
        //}

        //public class LeaseId : Value<PictureId>
        //{
        //    public PictureId(Guid value) => Value = value;

        //    public Guid Value { get; }

        //    protected PictureId() { }
        //}
    }
}
