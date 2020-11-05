using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain.Shared.Events
{
    public static class LeaseOrderLineEvents
    {
        public class CreateLeaseOrderLine 
        {
            public Guid LeaseOrderLineId { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public bool IsReturned { get; set; }

            public string RessourceName { get; set; }

            public decimal RessourcePrice { get; set; }

            public int Quantity { get;  set; }

            public decimal LineTotalPrice { get; set; }
        }

        public class UpdateStartDate
        {
            public Guid LeaseOrderLineId { get; set; }

            public DateTime StartDate { get; set; }
        }

        public class UpdateEndDate
        {
            public Guid LeaseOrderLineId { get; set; }

            public DateTime EndDate { get; set; }
        }

        public class UpdateIsReturned
        {
            public Guid LeaseOrderLineId { get; set; }

            public bool IsReturned { get; set; }
        }

        public class UpdateRessourceName
        {
            public Guid LeaseOrderLineId { get; set; }

            public string RessourceName { get;  set; }
        }

        public class UpdateRessourcePrice
        {
            public Guid LeaseOrderLineId { get; set; }

            public decimal RessourcePrice { get;  set; }
        }

        public class UpdateQuantity
        {
            public Guid LeaseOrderLineId { get; set; }

            public int Quantity { get;  set; }
        }

        public class UpdateLineTotalPrice
        {
            public Guid LeaseOrderLineId { get; set; }

            public decimal LineTotalPrice { get;  set; }
        }
    }
}
