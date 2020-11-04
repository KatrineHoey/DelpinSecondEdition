using System;

namespace Lease.Microservice.Lease
{
    public static class QueryModels
    {
        public class GetLeaseById
        {
            public Guid LeaseId { get; set; }
        }
    }
}