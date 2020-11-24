using System;


namespace Delpin.Shared.ResourceModels
{
    public static class ReadModels
    {
        public class ResourceDetails
        {
            public Guid ResourceId { get; set; }
            public string ResourceName { get; set; }
            public int ResourceNo { get; set; }
            public decimal ResourcePrice { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class Resources
        {
            public string ResourceName { get; set; }
            public int ResourceNo { get; set; }
            public decimal ResourcePrice { get; set; }
            public bool IsDeleted { get; set; }
        }

    }
}
