using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Delpin.Shared.CustomerModels
{
    public enum CustomerTypeEnum
    {
        Erhverv = 1,
        Privat = 2
    }
    public static class CustomerDto
    {
        public class CustomerDetails
        {
            public Guid CustomerId { get; set; }
            [Required(ErrorMessage ="Navn mangler.")]
            public string FullName { get; set; }
            [Required(ErrorMessage = "Mobilnr. mangler.")]
            public int PhoneNo { get; set; }
            [Required(ErrorMessage = "Email mangler.")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Type kunde mangler.")]
            public CustomerTypeEnum CustomerType { get; set; }
            [Required(ErrorMessage = "Vejnavn og nr. mangler.")]
            public string Street { get; set; }
            [Required(ErrorMessage = "Postnummer mangler.")]
            public int ZipCode { get; set; }
            [Required(ErrorMessage = "Bynavn mangler.")]
            public string City { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class ActiveCustomerSearchListItem
        {
            public Guid CustomerId { get; set; }
            public string FullName { get; set; }
            public int PhoneNo { get; set; }
            public string City { get; set; }

        }
    }
}
