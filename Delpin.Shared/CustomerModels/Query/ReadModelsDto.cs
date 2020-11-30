﻿
using Delpin.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delpin.Shared.CustomerModels
{
    public static class ReadModelsDto
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
