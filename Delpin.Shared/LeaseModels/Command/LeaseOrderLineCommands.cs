using System;
using System.Collections.Generic;
using System.Text;

namespace Delpin.Shared.LeaseModels
{
    public static class LeaseOrderLineCommands
    {
        public static class V1
        {
            public class AddLeaseOrderLineToLeaseOrder
            {
                public Guid LeaseId { get; set; }

                public Guid LeaseOrderLineId { get; set; }

                public Guid ResourceId { get; set; }

                public DateTime StartDate { get; set; }

                public DateTime EndDate { get; set; }

                public bool IsReturned { get; set; }

                public string ResourceName { get; set; }

                public int ResourcePrice { get; set; }

                public int Quantity { get; set; }

            }

            public class UpdateLeaseOrderLine
            {
                public Guid LeaseOrderLineId { get; set; }

                public DateTime StartDate { get; set; }

                public DateTime EndDate { get; set; }

                public bool IsReturned { get; set; }

                public string ResourceName { get; set; }

                public int ResourcePrice { get; set; }

                public int Quantity { get; set; }

            }
            public class DeleteLeaseOrderLine
            {
                public Guid LeaseId { get; set; }
            }
        }
    }
}
