using System;

namespace Lease.Infrastructure
{
    public static class QueryModels
    {
        public class GetLeaseById
        {
            public Guid LeaseId { get; set; }
        }
    }
}