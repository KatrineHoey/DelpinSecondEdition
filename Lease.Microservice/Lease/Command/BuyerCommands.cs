using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lease.Microservice.Lease.Command
{
    public static class BuyerCommands
    {
        public static class V1
        {
            public class CreateBuyer
            {
                public Guid BuyerId { get; set; }
                public string BuyerName { get; set; }
            }

            public class UpdateBuyer
            {
                public Guid BuyerId { get; set; }
                public string BuyerName { get; set; }
            }

            public class DeleteBuyer
            {
                public Guid BuyerId { get; set; }
            }
        }
    }
}
