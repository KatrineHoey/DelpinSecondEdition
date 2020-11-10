
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lease.Domain.InterFace
{
    public interface ILeaseRepository
    {
        //LeaseOrder
        Task<LeaseOrder> LoadLeaseOrder(Guid id);

        Task AddLeaseOrder(LeaseOrder entity);

        Task<bool> LeaseOrderExists(Guid id);

        ////LeaseOrderLine
        Task<LeaseOrderLine> LoadLeaseOrderLine(Guid id);

        Task AddLeaseOrderLine(LeaseOrderLine entity);

        Task<bool> LeaseOrderLineExists(Guid id);
        Task DeleteLeaseOrderLine(Guid id);
    }
}
