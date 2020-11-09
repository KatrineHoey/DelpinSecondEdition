using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain.Shared.Events
{
    public static class LeaseOrderEvents
    {
        public class CreateLeaseOrder
        {
            public Guid LeaseId { get; set; }

            public Guid CustomerId { get; set; }
            public DateTime DateCreated { get; set; }

            public bool IsDeleted { get; set; }

            public bool IsDelivery { get; set; }

            public bool IsPaid { get; set; }

            public decimal TotalPrice { get; set; }

            public string Street { get; set; }

            public int ZipCode { get; set; }

            public string City { get; set; }
        }

        public class DateCreatedUpdated
        {
            public Guid LeaseId { get; set; }

            public DateTime DateCreated { get; set; }
        }

        public class LeaseDeleted 
        {
            public Guid LeaseId { get; set; }

            public bool IsDeleted { get; set; }
        }

        public class IsDeliveryUpdated
        {
            public Guid LeaseId { get; set; }

            public bool IsDelivery { get; set; }
        }

        public class IsPaidUpdated 
        {
            public Guid LeaseId { get; set; }

            public bool IsPaid { get; set; }
        }

        public class TotalPriceUpdated 
        {
            public Guid LeaseId { get; set; }

            public decimal TotalPrice { get; set; }
        }

        public class LeaseStreetUpdated
        {
            public Guid LeaseId { get; set; }

            public string Street { get; set; }
        }

        public class LeaseZipCodeUpdated
        {
            public Guid LeaseId { get; set; }

            public int ZipCode { get; set; }            
        }

        public class LeaseCityUpdated
        {
            public Guid LeaseId { get; set; }

            public string City { get; set; }
        }

        public class LeaseOrderLineAddedToLeaseOrder 
        {
            public Guid LeaseOrderId { get; set; }

            public Guid LeaseOrderLineId { get; set; }

            public DateTime StartDate { get;  set; }

            public DateTime EndDate { get;  set; }

            public bool IsReturned { get;  set; }

            public string RessourceName { get;  set; }

            public decimal RessourcePrice { get;  set; }

            public int Quantity { get;  set; }

            //public decimal LineTotalPrice { get;  set; }

        }
    }
}
