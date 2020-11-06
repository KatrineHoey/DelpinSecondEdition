using System;

namespace Lease.Infrastructure.Lease
{
    public static class ReadModels
    {
        public class LeaseOrderDetails
        {
            public Guid LeaseId { get; set; }

            public string Street { get; set; }

            public int ZipCode { get; set; }

            public string City { get; set; }

            public DateTime DateCreated { get; set; }

            public bool IsDeleted { get; set; }

            public bool IsDelivery { get; set; }

            public bool IsPaid { get; set; }

            public decimal TotalPrice { get; set; }
        }

        public class LeaseOrderLineDetails
        {
            public Guid LeaseOrderLineId { get; set; }

            public DateTime StartDate { get;  set; }

            public DateTime EndDate { get;  set; }

            public bool IsReturned { get;  set; }

            public string RessourceName { get;  set; }

            public decimal RessourcePrice { get;  set; }

            public int Quantity { get;  set; }

            public decimal LineTotalPrice { get;  set; }
        }
    }
}