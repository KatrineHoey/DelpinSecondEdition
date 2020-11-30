using System;
using System.Collections.Generic;
using System.Text;

namespace Delpin.Shared.ResourceModels
{
    public static class ResourceDto
    {
        public class ResourceDetails
        {
            public Guid ResourceId { get; set; }

            public string ResourceName { get; set; }
            
            public int ResourceNo { get; set; }
            
            public int ResourcePrice { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
