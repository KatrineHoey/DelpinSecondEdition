using System;

namespace Lease.Microservice.Lease
{
    public static class QueryModels
    {
        public class GetLeaseOrderById
        {
            public Guid LeaseId { get; set; }
        }
    }
}