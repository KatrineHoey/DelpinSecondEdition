using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class Buyer : Entity<BuyerId>
    {
        // Properties to handle the persistence
        public Guid BuyerId { get; private set; }

        protected Buyer() { }
        // Entity state properties

        public BuyerName BuyerName { get; set; }

        public List<LeaseOrder> LeaseOrders { get; set; }

        public Buyer(Guid BuyerId, BuyerName buyerName)
        {
            Apply(new BuyerEvents.BuyerCreated
            {
                BuyerId = BuyerId,
                BuyerName = buyerName
            });
        }

        public void UpdateBuyer(BuyerName buyerName)
        {
            Apply(new BuyerEvents.BuyerUpdated
            {
                BuyerId = BuyerId,
                BuyerName = buyerName
            });
        }

        public void BuyerDeleted()
        {
            Apply(new BuyerEvents.BuyerDeleted
            {
                BuyerId = BuyerId
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {

                case BuyerEvents.BuyerCreated e:
                    BuyerId = e.BuyerId;
                    BuyerName = new BuyerName(e.BuyerName);
                    break;

                case BuyerEvents.BuyerUpdated e:
                    Id = new BuyerId(e.BuyerId);
                    BuyerName = new BuyerName(e.BuyerName);
                    break;


                case BuyerEvents.BuyerDeleted e:
                    Id = new BuyerId(e.BuyerId);
                    break;
            }
        }

        public Buyer(Action<object> applier) : base(applier)
        {
        }
    }
}
