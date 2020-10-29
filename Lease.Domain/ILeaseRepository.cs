using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lease.Domain
{
    public interface ILeaseRepository
    {
        Task<Lease> Load(LeaseId id);

        Task Add(Lease entity);

        Task<bool> Exists(LeaseId id);
    }
}
