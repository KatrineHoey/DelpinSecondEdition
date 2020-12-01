using System;
using System.Collections.Generic;
using System.Text;

namespace Resource.Domain.Shared
{
    public class Events
    {
        public class ResourceRegistered
        {
            public Guid ResourceId { get; set; }
            public int ResourceNo { get; set; }
            public string ResourceName { get; set; }
            public int ResourcePrice { get; set; }            
        }

        public class ResourceDeleted
        {
            public Guid ResourceId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class ResourceNoUpdated
        {
            public Guid ResourceId { get; set; }
            public int ResourceNo { get; set; }
        }

        public class ResourceNameUpdated
        {
            public Guid ResourceId { get; set; }
            public string ResourceName { get; set; }
        }

        public class ResourcePriceUpdated
        {
            public Guid ResourceId { get; set; }
            public int ResourcePrice { get; set; }
        }

    }
}
