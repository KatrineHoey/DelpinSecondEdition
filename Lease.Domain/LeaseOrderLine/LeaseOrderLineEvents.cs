﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public static class LeaseOrderLineEvents
    {
        public class LeaseOrderLineDeleted
        {
            public Guid LeaseOrderLineId { get; set; }
        }

        public class LeaseOrderLineAddedToLeaseOrder
        {
            public Guid LeaseOrderId { get; set; }

            public Guid LeaseOrderLineId { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public bool IsReturned { get; set; }

            public string ResourceName { get; set; }

            public int ResourcePrice { get; set; }

            public int Quantity { get; set; }

            public Guid ResourceId { get; set; }

        }

        public class LeaseOrderLineUpdated
        {
            public Guid LeaseOrderLineId { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public bool IsReturned { get; set; }

            public string ResourceName { get; set; }

            public int ResourcePrice { get; set; }

            public int Quantity { get; set; }

        }
    }
}
