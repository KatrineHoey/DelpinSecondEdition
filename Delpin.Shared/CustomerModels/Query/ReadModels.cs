using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.Shared.CustomerModels
{
    public enum CustomerTypeEnum
    {
        Erhverv = 1,
        Privat = 2
    }
    public static class ReadModels
    {
        public class CustomerDetails
        {
            public Guid CustomerId { get; set; }
            public string FullName { get; set; }
            public int PhoneNo { get; set; }
            public string Email { get; set; }
            public CustomerTypeEnum CustomerType { get; set; }
            public string Street { get; set; }
            public int ZipCode { get; set; }
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
