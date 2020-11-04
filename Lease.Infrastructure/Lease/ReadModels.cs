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
    }
}