using System;
using System.Collections.Generic;
using System.Text;
using Delpin.Framework;
using Lease.Domain.Shared;

namespace Lease.Domain
{
    public class LeaseOrder : AggregateRoot<LeaseId>
    {
        // Properties to handle the persistence
        public Guid leaseId { get; private set; }

        
        // Aggregate state properties

        public DateCreated DateCreated { get; private set; }

        public IsDeleted IsDeleted { get; private set; }

        public IsDelivery IsDelivery { get; private set; }

        public IsPaid IsPaid { get; private set; }

        public TotalPrice TotalPrice { get; private set; }

        public Street Street { get; private set; }

        public ZipCode ZipCode { get; private set; }

        public City City { get; private set; }


        public LeaseState State { get; private set; }


        public LeaseOrder(LeaseId leaseId, DateCreated dateCreated, IsDelivery isDelivery, IsPaid isPaid, Street street, ZipCode zipCode, City city)
        {
            Apply(new Events.CreateLeaseOrder
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

        protected LeaseOrder()
        {

        }

        public void LeaseStreetUpdate(Street street)
        {
            Apply(new Events.LeaseStreetUpdated
            {
                LeaseId = leaseId,
                Street = street
                
            });
        }

        public void LeaseZipCodeUpdate(ZipCode zipCode)
        {
            Apply(new Events.LeaseZipCodeUpdated
            {
                LeaseId = leaseId,
                ZipCode = zipCode
                
            });
        }

        public void LeaseCityUpdate(City city)
        {
            Apply(new Events.LeaseCityUpdated
            {
                LeaseId = leaseId,
                City = city,
                
            });
        }

        public void DateCreatedUpdated(DateCreated dateCreated)
        {
            Apply(new Events.DateCreatedUpdated
            {
                LeaseId = leaseId,
                DateCreated = dateCreated
            });
        }

        public void LeaseDeleted(IsDeleted isDeleted)
        {
            Apply(new Events.LeaseDeleted
            {
                LeaseId = leaseId,
                IsDeleted = isDeleted
            });
        }

        public void IsDeliveryUpdated(IsDelivery isDelivery)
        {
            Apply(new Events.IsDeliveryUpdated
            {
                LeaseId = leaseId,
                IsDelivery = isDelivery
            });
        }

        public void IsPaidUpdated(IsPaid isPaid)
        {
            Apply(new Events.IsPaidUpdated
            {
                LeaseId = leaseId,
                IsPaid = isPaid
            });
        }

        public void TotalPriceUpdated(TotalPrice totalPrice)
        {
            Apply(new Events.TotalPriceUpdated
            {
                LeaseId = leaseId,
                TotalPrice = totalPrice
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.CreateLeaseOrder e:
                    Id = new LeaseId(e.LeaseId);

                    DateCreated = new DateCreated(e.DateCreated);
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    IsDelivery = new IsDelivery(e.IsDelivery);
                    IsPaid = new IsPaid(e.IsPaid);
                    TotalPrice = new TotalPrice(e.TotalPrice);
                    Street = new Street(e.Street);
                    ZipCode = new ZipCode(e.ZipCode);
                    City = new City(e.City);
                    break;

                case Events.LeaseStreetUpdated e:
                    Id = new LeaseId(e.LeaseId);
                    Street = new Street(new Street(e.Street));
                    break;

                case Events.LeaseZipCodeUpdated e:
                    Id = new LeaseId(e.LeaseId);
                    ZipCode = new ZipCode(new ZipCode(e.ZipCode));
                    break;

                case Events.LeaseCityUpdated e:
                    Id = new LeaseId(e.LeaseId);
                    City = new City(new City(e.City));
                    break;

                case Events.DateCreatedUpdated e:
                    Id = new LeaseId(e.LeaseId);
                    DateCreated = new DateCreated(e.DateCreated);
                    break;

                case Events.LeaseDeleted e:
                    Id = new LeaseId(e.LeaseId);
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    break;

                case Events.IsDeliveryUpdated e:
                    Id = new LeaseId(e.LeaseId);
                    IsDelivery = new IsDelivery(e.IsDelivery);
                    break;

                case Events.IsPaidUpdated e:
                    Id = new LeaseId(e.LeaseId);
                    IsPaid = new IsPaid(e.IsPaid);
                    break;

                case Events.TotalPriceUpdated e:
                    Id = new LeaseId(e.LeaseId);
                    TotalPrice = new TotalPrice(e.TotalPrice);
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
