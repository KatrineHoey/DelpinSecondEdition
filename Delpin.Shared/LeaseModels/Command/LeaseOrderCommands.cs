using System;
using System.Security.Permissions;

namespace Delpin.Shared.LeaseModels
{ 

    public static class LeaseOrderCommands
    {
        public static class V1
        {
            public class CreateLease
            {
                public Guid LeaseId { get; set; }

                public Guid BuyerId { get; set; }

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


            public class DeleteLease
            {
                public Guid LeaseId { get; set; }
                public bool IsDeleted { get; set; }
            }

        }
    }
}