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

        public BuyerName BuyerName { get; private set; }

        public List<LeaseOrder> LeaseOrders { get; private set; }

        public Buyer(BuyerId BuyerId, BuyerName buyerName)
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

        protected override void When(object @event)
        {
            switch (@event)
            {

                case BuyerEvents.BuyerCreated e:
                    BuyerId = new BuyerId(e.BuyerId);
                    BuyerName = new BuyerName(e.BuyerName);
                    break;

                case BuyerEvents.BuyerUpdated e:
                    BuyerName = new BuyerName(e.BuyerName);
                    break;
            }
        }

        public Buyer(Action<object> applier) : base(applier)
        {
        }
    }
}
