using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Query
{
    public static class QueryModels
    {
        public class GetSearchedActiveCustomers
        {
            public string SearchTerm { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }

        public class GetCustomerById
        {
            public Guid CustomerId { get; set; }
        }
    }
}
