using System;
using System.Collections.Generic;
using System.Text;
using Delpin.Framework;
using Lease.Domain.Shared;

namespace Lease.Domain
{
    public class Lease : AggregateRoot<LeaseId>
    {
        // Properties to handle the persistence
        public Guid leaseId { get; private set; }

        
        // Aggregate state properties

        public Adresse Adresse { get; set; }

        public DateCreated DateCreated { get; set; }

        public IsDeleted IsDeleted { get; set; }

        public IsDelivery IsDelivery { get; set; }

        public IsPaid IsPaid { get; set; }

        public TotalPrice TotalPrice { get; set; }

        public LeaseState State { get; private set; }


        public Lease(LeaseId leaseId, Adresse adresse, DateCreated dateCreated, IsDeleted isDeleted, IsDelivery isDelivery, IsPaid isPaid, TotalPrice totalPrice)
        {
            Apply(new Events.LeaseRegistered
            {
                LeaseId = leaseId,
                DateCreated = dateCreated,
                IsDeleted = isDeleted,
                IsDelivery = isDelivery,
                IsPaid = isPaid,
                TotalPrice = totalPrice,
                Street = adresse.Street,
                ZipCode = adresse.ZipCode,
                City = adresse.City

            });
        }

        protected Lease()
        {

        }

        public void LeaseAdresseUpdate(Adresse adresse)
        {
            Apply(new Events.LeaseAdresseUpdated
            {
                LeaseId = leaseId,
                City = adresse.City,
                Street = adresse.Street,
                ZipCode = adresse.ZipCode
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
                case Events.LeaseRegistered e:
                    Id = new LeaseId(e.LeaseId);
                    Adresse = new Adresse(new Street(e.Street), new ZipCode(e.ZipCode), new City(e.City));
                    DateCreated = new DateCreated(e.DateCreated);
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    IsDelivery = new IsDelivery(e.IsDelivery);
                    IsPaid = new IsPaid(e.IsPaid);
                    TotalPrice = new TotalPrice(e.TotalPrice);
                    break;

                case Events.LeaseAdresseUpdated e:
                    Id = new LeaseId(e.LeaseId);
                    Adresse = new Adresse(new Street(e.Street), new ZipCode(e.ZipCode), new City(e.City));
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
                        Adresse != null
                        && DateCreated != null
                        && IsDeleted != null
                        && IsDelivery != null
                        && IsPaid != null
                        && TotalPrice != null ,
                        
                    LeaseState.Active =>
                        Adresse != null
                        && DateCreated != null
                        && IsDeleted != null
                        && IsDelivery != null
                        && IsPaid != null
                        && TotalPrice != null,
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
