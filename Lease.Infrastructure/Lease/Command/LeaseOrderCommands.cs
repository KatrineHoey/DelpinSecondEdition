using System;
using System.Security.Permissions;

namespace Lease.Infrastructure.Lease
{
    public static class LeaseOrderCommands
    {
        public static class V1
        {
            public class CreateLease
            {
                public Guid LeaseId { get; set; }

                public Guid CustomerId { get; set; }

                public string Street { get; set; }

                public int ZipCode { get; set; }

                public string City { get; set; }

                public bool IsDelivery { get; set; }

                public bool IsPaid { get; set; }
            }

            public class UpdateAddress
            {
                public Guid LeaseId { get; set; }
                public string Street { get; set; }
                public int ZipCode { get; set; }
                public string City { get; set; }

            }

            public class DeleteLease
            {
                public Guid LeaseId { get; set; }
                public bool IsDeleted { get; set; }
            }

            public class DeleteLeaseOrderLine
            {
                public Guid LeaseId { get; set; }
            }

            public class UpdateIsDelivery
            {
                public Guid LeaseId { get; set; }
                public bool IsDelivery { get; set; }
            }

            public class UpdateIsPaid
            {
                public Guid LeaseId { get; set; }
                public bool IsPaid { get; set; }
            }

            public class UpdateTotalPrice
            {
                public Guid LeaseId { get; set; }
                public int TotalPrice { get; set; }
            }

            public class AddLeaseOrderLineToLeaseOrder 
            {
                public Guid LeaseId { get; set; }

                public Guid LeaseOrderLineId { get; set; }

                public DateTime StartDate { get; set; }

                public DateTime EndDate { get; set; }

                public bool IsReturned { get; set; }

                public string RessourceName { get; set; }

                public int RessourcePrice { get; set; }

                public int Quantity { get; set; }

            }

            public class UpdateLeaseOrderLine
            {
                public Guid LeaseOrderLineId { get; set; }

                public DateTime StartDate { get; set; }

                public DateTime EndDate { get; set; }

                public bool IsReturned { get; set; }

                public string RessourceName { get; set; }

                public int RessourcePrice { get; set; }

                public int Quantity { get; set; }

            }
        }
    }
}