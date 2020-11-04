using System;

namespace Lease.Microservice.Lease
{
    public static class LeaseOrderCommands
    {
        public static class V1
        {
            public class CreateLease
            {
                public Guid LeaseId { get; set; }

                public string Street { get; set; }

                public int ZipCode { get; set; }

                public string City { get; set; }

                public DateTime DateCreated { get; set; }
                
                public bool IsDelivery { get; set; }

                public bool IsPaid { get; set; }
            }

            public class UpdateLeaseStreet
            {
                public Guid LeaseId { get; set; }
                public string Street { get; set; }
   
            }

            public class UpdateLeaseZipCode
            {
                public Guid LeaseId { get; set; }
                
                public int ZipCode { get; set; }
                
            }

            public class UpdateLeaseCity
            {
                public Guid LeaseId { get; set; }
                public string City { get; set; }
            }

            public class UpdateDateCreated
            {
                public Guid LeaseId { get; set; }
                public DateTime DateCreated { get; set; }
            }

            public class DeleteLease
            {
                public Guid LeaseId { get; set; }
                public bool IsDeleted { get; set; }
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
                public decimal TotalPrice { get; set; }
            }
        }
    }
}