using System;

namespace Lease.Intrastructure.Query
{ 

    public static class QueryModels
    {
        public class GetLeaseOrderById
        {
            public Guid LeaseId { get; set; }
        }

        public class GetLeaseOrderLineById 
        {
            public Guid LeaseOrderLineId { get; set; }
        }

        public class GetSearchedLeases
        {
            public string SearchTerm { get; set; }

            public int Page { get; set; }

            public int PageSize { get; set; }
        }

        public class GetLeasesByBuyerId
        {
            public Guid BuyerId { get; set; }
        }

    }
}