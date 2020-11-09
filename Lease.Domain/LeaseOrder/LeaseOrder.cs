using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delpin.Framework;

using Lease.Domain.Shared;
using Lease.Domain.Shared.Events;

namespace Lease.Domain
{
    public class LeaseOrder : AggregateRoot<LeaseOrderId>
    {
        // Properties to handle the persistence
        public Guid leaseId { get; private set; }

        protected LeaseOrder() { }


        // Aggregate state properties

        public DateCreated DateCreated { get; private set; }

        public IsDeleted IsDeleted { get; private set; }

        public IsDelivery IsDelivery { get; private set; }

        public IsPaid IsPaid { get; private set; }

        public TotalPrice TotalPrice { get; private set; }

        public Street Street { get; private set; }

        public ZipCode ZipCode { get; private set; }

        public City City { get; private set; }

        public List<LeaseOrderLine> LeaseOrderLines { get; }


        public LeaseState State { get; private set; }


        public LeaseOrder(LeaseOrderId leaseId, DateCreated dateCreated, IsDelivery isDelivery, IsPaid isPaid, Street street, ZipCode zipCode, City city)
        {
            LeaseOrderLines = new List<LeaseOrderLine>();
            Apply(new LeaseOrderEvents.CreateLeaseOrder
            {
                LeaseId = leaseId,
                DateCreated = dateCreated,
                IsDelivery = isDelivery,
                IsPaid = isPaid,
                Street = street,
                ZipCode = zipCode,
                City = city
                
            });
        }

        public void LeaseStreetUpdate(Street street)
        {
            Apply(new LeaseOrderEvents.LeaseStreetUpdated
            {
                LeaseId = leaseId,
                Street = street
                
            });
        }

        public void LeaseZipCodeUpdate(ZipCode zipCode)
        {
            Apply(new LeaseOrderEvents.LeaseZipCodeUpdated
            {
                LeaseId = leaseId,
                ZipCode = zipCode
                
            });
        }

        public void LeaseCityUpdate(City city)
        {
            Apply(new LeaseOrderEvents.LeaseCityUpdated
            {
                LeaseId = leaseId,
                City = city,
                
            });
        }

        public void DateCreatedUpdated(DateCreated dateCreated)
        {
            Apply(new LeaseOrderEvents.DateCreatedUpdated
            {
                LeaseId = leaseId,
                DateCreated = dateCreated
            });
        }

        public void LeaseDeleted(IsDeleted isDeleted)
        {
            Apply(new LeaseOrderEvents.LeaseDeleted
            {
                LeaseId = leaseId,
                IsDeleted = isDeleted
            });
        }

        public void IsDeliveryUpdated(IsDelivery isDelivery)
        {
            Apply(new LeaseOrderEvents.IsDeliveryUpdated
            {
                LeaseId = leaseId,
                IsDelivery = isDelivery
            });
        }

        public void IsPaidUpdated(IsPaid isPaid)
        {
            Apply(new LeaseOrderEvents.IsPaidUpdated
            {
                LeaseId = leaseId,
                IsPaid = isPaid
            });
        }

        public void TotalPriceUpdated(TotalPrice totalPrice)
        {
            Apply(new LeaseOrderEvents.TotalPriceUpdated
            {
                LeaseId = leaseId,
                TotalPrice = totalPrice
            });
        }

        //public void AddLeaseOrderLine(LeaseOrderLine leaseOrderLine)
        //{
        //    Apply(new LeaseOrderEvents.LeaseOrderLineAddedToLeaseOrder
        //    {
        //        LeaseOrderLineId = new Guid(),
        //        LeaseOrderId = Id,
        //        StartDate = leaseOrderLine.StartDate,
        //        EndDate = leaseOrderLine.EndDate,
        //        IsReturned = leaseOrderLine.IsReturned,
        //        RessourceName = leaseOrderLine.RessourceName,
        //        RessourcePrice = leaseOrderLine.RessourcePrice,
        //        Quantity = leaseOrderLine.Quantity,
        //        //LineTotalPrice = leaseOrderLine.LineTotalPrice
        //    });

        //}

        protected override void When(object @event)
        {
            LeaseOrderLine leaseOrderLine;

            switch (@event)
            {
                case LeaseOrderEvents.CreateLeaseOrder e:
                    Id = new LeaseOrderId(e.LeaseId);

                    DateCreated = new DateCreated(e.DateCreated);
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    IsDelivery = new IsDelivery(e.IsDelivery);
                    IsPaid = new IsPaid(e.IsPaid);
                    TotalPrice = new TotalPrice(e.TotalPrice);
                    Street = new Street(e.Street);
                    ZipCode = new ZipCode(e.ZipCode);
                    City = new City(e.City);
                    break;

                case LeaseOrderEvents.LeaseStreetUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    Street = new Street(e.Street);
                    break;

                case LeaseOrderEvents.LeaseZipCodeUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    ZipCode = new ZipCode(e.ZipCode);
                    break;

                case LeaseOrderEvents.LeaseCityUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    City = new City(e.City);
                    break;

                case LeaseOrderEvents.DateCreatedUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    DateCreated = new DateCreated(e.DateCreated);
                    break;

                case LeaseOrderEvents.LeaseDeleted e:
                    Id = new LeaseOrderId(e.LeaseId);
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    break;

                case LeaseOrderEvents.IsDeliveryUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    IsDelivery = new IsDelivery(e.IsDelivery);
                    break;

                case LeaseOrderEvents.IsPaidUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    IsPaid = new IsPaid(e.IsPaid);
                    break;

                case LeaseOrderEvents.TotalPriceUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    TotalPrice = new TotalPrice(e.TotalPrice);
                    break;

                // LeaseOrderLine
                case LeaseOrderEvents.LeaseOrderLineAddedToLeaseOrder e:
                    leaseOrderLine = new LeaseOrderLine(Apply);
                    ApplyToEntity(leaseOrderLine, e);
                    LeaseOrderLines.Add(leaseOrderLine);
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid =
                Id != null &&
                (State switch
                {
                    LeaseState.PendingReview =>
                         DateCreated != null
                        && IsDeleted != null
                        && IsDelivery != null
                        && IsPaid != null
                        && TotalPrice != null
                        && Street != null
                        && ZipCode != null
                        && City != null,

                    LeaseState.Active =>
                         DateCreated != null
                        && IsDeleted != null
                        && IsDelivery != null
                        && IsPaid != null
                        && TotalPrice != null
                        && Street != null
                        && ZipCode != null
                        && City != null,


                    _ => true
                });

            if (!valid)
                throw new DomainExceptions.InvalidEntityState(this, $"Post-checks failed in state {State}");
        }

        public enum LeaseState
        {
            PendingReview = 1,
            Active = 2,
            Inactive = 3,
            MarkedAsSold = 4
        }
    }
}
