using System;
using System.Collections.Generic;
using System.Text;

namespace Delpin.Shared.ResourceModels
{
    public static class ResourceDto
    {
        public class ResourceDetails
        {            
            public string ResourceName { get; set; }
            
            public int ResourceNo { get; set; }
            
            public decimal ResourcePrice { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
