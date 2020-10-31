using System;
using System.Collections.Generic;
using System.Text;
using static Customer.Domain.Customer.CustomerType;

namespace Customer.Domain.Customer
{
    public static class Events
    {
        public class CustomerRegistered
        {
            public Guid CustomerId { get; set; }
            public string FullName { get; set; }
            public int PhoneNo { get; set; }
            public string Email { get; set; }
            public CustomerTypeEnum CustomerType { get; set; }
            public string Street { get; set; }
            public int ZipCode { get; set; }
            public string City { get; set; }

        }

        public class CustomerTypeChanged
        {
            public Guid CustomerId { get; set; }
            public CustomerTypeEnum CustomerType { get; set; }
        }

        public class CustomerDeleted
        {
            public Guid CustomerId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class CustomerFullNameUpdated
        {
            public Guid CustomerId { get; set; }
            public string FullName { get; set; }
        }

        public class CustomerAdresseUpdated
        {
            public Guid CustomerId { get; set; }
            public string Street { get; set; }
            public int ZipCode { get; set; }
            public string City { get; set; }
        }

        public class CustomerEmailUpdated
        {
            public Guid CustomerId { get; set; }
            public string Email { get; set; }
        }

        public class CustomerPhoneNoUpdated
        {
            public Guid CustomerId { get; set; }
            public int PhoneNo { get; set; }
        }
    }
}
