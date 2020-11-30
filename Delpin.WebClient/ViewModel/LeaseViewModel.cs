using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.ViewModel
{
    public class LeaseViewModel
    {
        public class LeaseOrderDetails
        {
            public Guid LeaseId { get; set; }

            [Required(ErrorMessage = "KundeId mangler.")]
            public Guid BuyerId { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public string BuyerName { get; set; }

            [Required(ErrorMessage = "Vejnavn og number mangler.")]
            public string Street { get; set; }

            [Required(ErrorMessage = "Postnummer mangler.")]
            public int ZipCode { get; set; }

            [Required(ErrorMessage = "By mangler.")]
            public string City { get; set; }

            [Required(ErrorMessage = "Dato mangler.")]
            public DateTime DateCreated { get; set; } = DateTime.UtcNow;

            public bool IsDeleted { get; set; }

            public bool IsDelivery { get; set; }

            public bool IsPaid { get; set; }

            public int TotalPrice { get; set; }

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
            public Guid LeaseId { get; set; }

            public Guid LeaseOrderLineId { get; set; }

            public Guid ResourceId { get; set; }

            [Required(ErrorMessage = "Start dato mangler.")]
            public DateTime StartDate { get; set; }

            [Required(ErrorMessage = "Slut dato mangler.")]
            public DateTime EndDate { get; set; }

            public bool IsReturned { get; set; }

            [Required(ErrorMessage = "Vare navn mangler.")]
            public string ResourceName { get; set; }

            [Required(ErrorMessage = "Vare pris mangler.")]
            public int ResourcePrice { get; set; }

            [Required(ErrorMessage = "Antal mangler.")]
            public int Quantity { get; set; }

            public int LineTotalPrice { get; set; }
        }

    }
}
