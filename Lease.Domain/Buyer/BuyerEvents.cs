using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public static class BuyerEvents
    {
        public class BuyerDeleted
        {
            public Guid BuyerId { get; set; }
        }

        public class BuyerCreated
        {
            public Guid BuyerId { get; set; }
            public string BuyerName { get; set; }

        }

        public class BuyerUpdated
        {
            public Guid BuyerId { get; set; }
            public string BuyerName { get; set; }

        }
    }
}
