using System;


namespace Resource.Microservice.Resource
{
    public static class QueryModels
    {
        public class GetPublicResource
        {
            public Guid ResourceId { get; set; }
        }

        public class GetNotDeleted
        {
            public bool Isdeleted { get; set; }
        }
    }
}
