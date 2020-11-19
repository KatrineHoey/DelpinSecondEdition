using Delpin.Shared.CustomerModels;
using Delpin.WebClient.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.WebClient.ViewModel
{
    public class CustomerViewModel
    {
        public class CustomerDetails
        {
            public Guid CustomerId { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Mobilnr. mangler.")]
            public int PhoneNo { get; set; }

            [Required(ErrorMessage = "Email mangler.")]
            public string Email { get; set; }

            public CustomerTypeEnum CustomerType { get; set; } = CustomerTypeEnum.Erhverv;

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
