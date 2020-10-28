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
        public Guid LeaseId { get; private set; }

        

        protected Lease() 
        {
        
        }

        // Aggregate state properties

        public Adresse Adresse { get; set; }

        public DateCreated DateCreated { get; set; }

        public IsDeleted IsDeleted { get; set; }

        public IsDelivery IsDelivery { get; set; }

        public IsPaid IsPaid { get; set; }

        public TotalPrice TotalPrice { get; set; }

        public LeaseState State { get; private set; }


        protected override void When(object @event)
        {
            switch (@event)
            {
                
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
