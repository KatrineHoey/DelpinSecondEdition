using System;
using System.Collections.Generic;
using System.Text;

namespace Delpin.Shared.LeaseModels
{
    public static class LeaseDto
    {
        public class LeaseOrderDetails
        {
            public Guid LeaseId { get; set; }

            public Guid CustomerId { get; set; }

            public string CustomerName { get; set; }

            public string Street { get; set; }

            public int ZipCode { get; set; }

            public string City { get; set; }

            public DateTime DateCreated { get; set; }

            public bool IsDeleted { get; set; }

            public bool IsDelivery { get; set; }

            public bool IsPaid { get; set; }

            public decimal TotalPrice { get; set; }

            public List<LeaseOrderLineDetails> leaseOrderLines { get; set; }
        }

        public class LeaseOrderListItem
        {
            public Guid LeaseId { get; set; }
            public DateTime DateCreated { get; set; }
            public string CustomerName { get; set; }
            public bool IsPaid { get; set; }
        }

        public class LeaseOrderLineDetails
        {
            public Guid LeaseOrderLineId { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public bool IsReturned { get; set; }

            public string RessourceName { get; set; }

            public decimal RessourcePrice { get; set; }

            public int Quantity { get; set; }

            public decimal LineTotalPrice { get; set; }
        }
    }
}
