using System;


namespace Resource.Microservice.Resource
{
    public static class Commands
    {
        public static class V1
        {
            //public class Create
            //{
            //    public Guid Id { get; set; }
            //}

            public class CreateResource
            {
                public Guid Id { get; set; }
                public string ResourceName { get; set; }
                public int ResourceNo { get; set; }
                public decimal ResourcePrice { get; set; }
            }

            public class UpdateName
            {
                public Guid Id { get; set; }
                public string Name { get; set; }
            }

            public class UpdateResourceNo
            {
                public Guid Id { get; set; }
                public int ResourceNo { get; set; }
            }

            public class UpdateResourcePrice
            {
                public Guid Id { get; set; }
                public decimal ResourcePrice { get; set; }
            }

            public class ResourceDeleted
            {
                public Guid Id { get; set; }
                public bool IsDeleted { get; set; }
            }

            public class RequestToPublish
            {
                public Guid Id { get; set; }
            }

            public class Publish
            {
                public Guid Id { get; set; }
                public Guid ApprovedBy { get; set; }
            }
        }
    }
}
