using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lease.Domain
{
    public interface ILeaseRepository
    {
        Task<LeaseOrder> Load(LeaseId id);

        Task Add(LeaseOrder entity);

        Task<bool> Exists(LeaseId id);
    }
}
