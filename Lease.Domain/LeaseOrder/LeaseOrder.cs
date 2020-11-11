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

        public DateTime DateCreated { get; private set; }

        public Guid CustomerId { get; private set; }

        public bool IsDeleted { get; private set; }

        public bool IsDelivery { get; private set; }

        public bool IsPaid { get; private set; }

        public int TotalPrice { get; private set; }

        public string Street { get; private set; }

        public int ZipCode { get; private set; }

        public string City { get; private set; }

        public List<LeaseOrderLine> LeaseOrderLines { get; }


        public LeaseState State { get; private set; }


        public LeaseOrder(Guid leaseId, Guid customerId, DateTime dateCreated, bool isDelivery, bool isPaid, string street, int zipCode, string city)
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
                CustomerId = customerId 
                
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

                    DateCreated = e.DateCreated;
                    IsDeleted = e.IsDeleted;
                    IsDelivery = e.IsDelivery;
                    IsPaid = e.IsPaid;
                    CustomerId = e.CustomerId;
                    TotalPrice = e.TotalPrice;
                    Street = e.Street;
                    ZipCode = e.ZipCode;
                    City = e.City;
                    break;

                case LeaseOrderEvents.LeaseAddressUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    Street = e.Street;
                    ZipCode = e.ZipCode;
                    City = e.City;
                    break;

                case LeaseOrderEvents.DateCreatedUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    DateCreated = e.DateCreated;
                    break;

                case LeaseOrderEvents.LeaseDeleted e:
                    Id = new LeaseOrderId(e.LeaseId);
                    IsDeleted = e.IsDeleted;
                    break;

                case LeaseOrderEvents.IsDeliveryUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    IsDelivery = e.IsDelivery;
                    break;

                case LeaseOrderEvents.IsPaidUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    IsPaid = e.IsPaid;
                    break;

                case LeaseOrderEvents.TotalPriceUpdated e:
                    Id = new LeaseOrderId(e.LeaseId);
                    TotalPrice = e.TotalPrice;
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
