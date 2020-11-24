using System;


namespace Resource.Intrastructure.Query
{
    public static class QueryModels
    {
        public class GetPublicResource
        {
            public Guid ResourceId { get; set; }
        }

        //public class GetNotDeleted
        //{
        //    public bool Isdeleted { get; set; }
        //}
    }
}
