
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lease.Domain.InterFace
{
    public interface ILeaseRepository
    {
        //LeaseOrder
        Task<LeaseOrder> LoadLeaseOrder(LeaseOrderId id);

        Task AddLeaseOrder(LeaseOrder entity);

        Task<bool> LeaseOrderExists(LeaseOrderId id);

        ////LeaseOrderLine
        //Task<LeaseOrderLine> LoadLeaseOrderLine(LeaseOrderLineId id);

        //Task AddLeaseOrderLine(LeaseOrderLine entity);

        //Task<bool> LeaseOrderLineExists(LeaseOrderLineId id);
    }
}
