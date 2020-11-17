using System;
using System.Collections.Generic;
using System.Text;

namespace Delpin.Shared.CustomerModels
{
    public static class CustomerCommandsDto
    {
        public static class V1
        {
            public class RegisterCustomer
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

            public class ChangeCustomerType
            {
                public Guid CustomerId { get; set; }
                public CustomerTypeEnum CustomerType { get; set; }
            }

            public class DeleteCustomer
            {
                public Guid CustomerId { get; set; }
                public bool IsDeleted { get; set; }
            }

            public class UpdateCustomerFullName
            {
                public Guid CustomerId { get; set; }
                public string FullName { get; set; }
            }

            public class UpdateCustomerAdresse
            {
                public Guid CustomerId { get; set; }
                public string Street { get; set; }
                public int ZipCode { get; set; }
                public string City { get; set; }
            }

            public class UpdateCustomerEmail
            {
                public Guid CustomerId { get; set; }
                public string Email { get; set; }
            }

            public class UpdateCustomerPhoneNo
            {
                public Guid CustomerId { get; set; }
                public int PhoneNo { get; set; }
            }
        }
    }
}
