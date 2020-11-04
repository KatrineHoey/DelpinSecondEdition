using System;

namespace Lease.Infrastructure.Lease
{
    public static class QueryModels
    {
        public class GetLeaseOrderById
        {
            public Guid LeaseId { get; set; }
        }
    }
}