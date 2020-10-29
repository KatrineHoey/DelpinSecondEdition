using System;

namespace Lease.Infrastructure
{
    public static class QueryModels
    {
        public class GetLease
        {
            public Guid LeaseId { get; set; }
        }
    }
}