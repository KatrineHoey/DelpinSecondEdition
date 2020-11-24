using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delpin.Framework;
using Lease.Domain.Shared;

namespace Lease.Domain
{
    public class LeaseOrder : Shared.AggregateRoot<LeaseOrderId>
    {
        // Properties to handle the persistence
        public Guid LeaseOrderId { get; private set; }

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

        public Guid BuyerId { get; set; }

        public Buyer Buyer { get; private set; }

        public List<LeaseOrderLine> LeaseOrderLines { get; }


        public LeaseOrder(LeaseOrderId leaseId, BuyerId buyerId, DateCreated dateCreated, IsDelivery isDelivery, IsPaid isPaid, Street street, ZipCode zipCode, City city)
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
                City = city,
                CustomerId = buyerId,
                
            });
        }


        public void LeaseAddressUpdated(Street street, ZipCode zipCode, City city)
        {
            Apply(new LeaseOrderEvents.LeaseAddressUpdated
            {
                LeaseId = LeaseOrderId,
                Street = street,
                ZipCode = zipCode,
                City = city
                
            });
        }

        public void LeaseDeleted(IsDeleted isDeleted)
        {
            Apply(new LeaseOrderEvents.LeaseDeleted
            {
                LeaseId = LeaseOrderId,
                IsDeleted = isDeleted
            });
        }



        public void IsDeliveryUpdated(IsDelivery isDelivery)
        {
            Apply(new LeaseOrderEvents.IsDeliveryUpdated
            {
                LeaseId = LeaseOrderId,
                IsDelivery = isDelivery
            });
        }

        public void IsPaidUpdated(IsPaid isPaid)
        {
            Apply(new LeaseOrderEvents.IsPaidUpdated
            {
                LeaseId = LeaseOrderId,
                IsPaid = isPaid
            });
        }

        public void TotalPriceUpdated(TotalPrice totalPrice)
        {
            Apply(new LeaseOrderEvents.TotalPriceUpdated
            {
                LeaseId = LeaseOrderId,
                TotalPrice = totalPrice
            });
        }



        protected override void When(object @event)
        {
            switch (@event)
            {
                case LeaseOrderEvents.CreateLeaseOrder e:
                    Id = new LeaseOrderId(e.LeaseId);

                    DateCreated =new DateCreated(e.DateCreated);
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    IsDelivery = new IsDelivery(e.IsDelivery);
                    IsPaid = new IsPaid(e.IsPaid);
                    BuyerId = new BuyerId(e.CustomerId);
                    TotalPrice = new TotalPrice(e.TotalPrice);
                    Street = new Street(e.Street);
                    ZipCode = new ZipCode(e.ZipCode);
                    City = new City(e.City);
                    break;

                case LeaseOrderEvents.LeaseAddressUpdated e:
                    Street = new Street(e.Street);
                    ZipCode = new ZipCode(e.ZipCode);
                    City = new City(e.City);
                    break;

                case LeaseOrderEvents.DateCreatedUpdated e:
                    DateCreated = new DateCreated(e.DateCreated);
                    break;

                case LeaseOrderEvents.LeaseDeleted e:
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    break;

                case LeaseOrderEvents.IsDeliveryUpdated e:
                    IsDelivery = new IsDelivery(e.IsDelivery);
                    break;

                case LeaseOrderEvents.IsPaidUpdated e:
                    IsPaid = new IsPaid(e.IsPaid);
                    break;

                case LeaseOrderEvents.TotalPriceUpdated e:
                    TotalPrice = new TotalPrice(e.TotalPrice);
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid = Id != null;

            if (!valid)
                throw new DomainExceptions.InvalidEntityState(this,
                    $"Post-checks failed.");
        }

    }
}
