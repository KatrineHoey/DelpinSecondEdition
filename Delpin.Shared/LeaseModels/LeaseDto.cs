using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Delpin.Shared.LeaseModels
{
    public static class LeaseDto
    {
        public class LeaseOrderDetails
        {
            public Guid LeaseId { get; set; }

            public Guid BuyerId { get; set; }
            
            public string BuyerName { get; set; }
            
            public string Street { get; set; }
            
            public int ZipCode { get; set; }
            
            public string City { get; set; }
            
            public DateTime DateCreated { get; set; } = DateTime.UtcNow;

            public bool IsDeleted { get; set; }

            public bool IsDelivery { get; set; }

            public bool IsPaid { get; set; }

            public decimal TotalPrice { get; set; }

            public List<LeaseOrderLineDetails> leaseOrderLines { get; set; } = new List<LeaseOrderLineDetails>();
        }

        public class LeaseOrderListItem
        {
            public Guid LeaseId { get; set; }
            public DateTime DateCreated { get; set; }
            public string CustomerName { get; set; }
            public bool IsPaid { get; set; }
        }

        public class AddLeaseOrderLineToLeaseOrder
        {
            public Guid LeaseId { get; set; }

            public Guid LeaseOrderLineId { get; set; }

            public Guid ResourceId { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public bool IsReturned { get; set; }

            public string ResourceName { get; set; }

            public int ResourcePrice { get; set; }

            public int Quantity { get; set; }

        }

        public class LeaseOrderLineDetails
        {
            public Guid LeaseOrderLineId { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public bool IsReturned { get; set; }

            public string ResourceName { get; set; }

            public decimal ResourcePrice { get; set; }

            public int Quantity { get; set; }

            public decimal LineTotalPrice { get; set; }
        }
    }
}
