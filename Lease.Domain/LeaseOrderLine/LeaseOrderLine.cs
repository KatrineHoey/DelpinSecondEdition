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
        public Guid LeaseOrderLineId
        {
            get => Id.Value;
            set { }
        }

        protected LeaseOrderLine() { }
        // Entity state properties

        public StartDate StartDate { get; private set; }

        public EndDate EndDate { get; private set; }

        public IsReturned IsReturned { get; private set; }

        public RessourceName RessourceName { get; private set; }

        public RessourcePrice RessourcePrice { get; private set; }

        public Quantity Quantity { get; private set; }

        public LineTotalPrice LineTotalPrice { get; private set; }

        public LeaseOrderId ParentId { get; private set; }

        //public LeaseOrderLineState State { get; private set; }

        public LeaseOrderLine(LeaseOrderLineId leaseOrderLineId, LeaseOrderId leaseOrderId, StartDate startDate, EndDate endDate, IsReturned isReturned, RessourceName ressourceName, RessourcePrice ressourcePrice, Quantity quantity)
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

        //public void UpdateStartDate(StartDate startDate)
        //{
        //    Apply(new LeaseOrderLineEvents.UpdateStartDate
        //    {
        //        LeaseOrderLineId = leaseOrderLineId,
        //        StartDate = startDate

        //    });
        //}

        //public void UpdateEndDate(EndDate endDate)
        //{
        //    Apply(new LeaseOrderLineEvents.UpdateEndDate
        //    {
        //        LeaseOrderLineId = leaseOrderLineId,
        //        EndDate = endDate

        //    });
        //}

        //public void UpdateIsReturned(IsReturned isReturned)
        //{
        //    Apply(new LeaseOrderLineEvents.UpdateIsReturned
        //    {
        //        LeaseOrderLineId = leaseOrderLineId,
        //        IsReturned = isReturned,

        //    });
        //}

        //public void UpdateRessourceName(RessourceName ressourceName)
        //{
        //    Apply(new LeaseOrderLineEvents.UpdateRessourceName
        //    {
        //        LeaseOrderLineId = leaseOrderLineId,
        //        RessourceName = ressourceName
        //    });
        //}

        //public void UpdateRessourcePrice(RessourcePrice ressourcePrice)
        //{
        //    Apply(new LeaseOrderLineEvents.UpdateRessourcePrice
        //    {
        //        LeaseOrderLineId = leaseOrderLineId,
        //        RessourcePrice = ressourcePrice
        //    });
        //}

        //public void UpdateQuantity(Quantity quantity)
        //{
        //    Apply(new LeaseOrderLineEvents.UpdateQuantity
        //    {
        //        LeaseOrderLineId = leaseOrderLineId,
        //        Quantity = quantity
        //    });
        //}

        //public void UpdateLineTotalPrice(LineTotalPrice lineTotalPrice)
        //{
        //    Apply(new LeaseOrderLineEvents.UpdateLineTotalPrice
        //    {
        //        LeaseOrderLineId = leaseOrderLineId,
        //        LineTotalPrice = lineTotalPrice
        //    });
        //}


        protected override void When(object @event)
        {
            switch (@event)
            {

                case LeaseOrderEvents.LeaseOrderLineAddedToLeaseOrder e:
                    ParentId = new LeaseOrderId(e.LeaseOrderId);
                    Id = new LeaseOrderLineId(e.LeaseOrderLineId);
                    
                    StartDate = new StartDate(e.StartDate);
                    EndDate = new EndDate(e.EndDate);
                    IsReturned = new IsReturned(e.IsReturned);
                    RessourceName = new RessourceName(e.RessourceName);
                    RessourcePrice = new RessourcePrice(e.RessourcePrice);
                    Quantity = new Quantity(e.Quantity);
                    //LineTotalPrice = new LineTotalPrice(e.LineTotalPrice);
                    break;

                    //case LeaseOrderLineEvents.CreateLeaseOrderLine e:
                    //    Id = new LeaseOrderLineId(e.LeaseOrderLineId);

                    //    StartDate = new StartDate(e.StartDate);
                    //    EndDate = new EndDate(e.EndDate);
                    //    IsReturned = new IsReturned(e.IsReturned);
                    //    RessourceName = new RessourceName(e.RessourceName);
                    //    RessourcePrice = new RessourcePrice(e.RessourcePrice);
                    //    Quantity = new Quantity(e.Quantity);
                    //    LineTotalPrice = new LineTotalPrice(e.LineTotalPrice);

                    //    break;

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
