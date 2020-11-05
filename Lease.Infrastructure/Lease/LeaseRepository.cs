using System;
using System.Threading.Tasks;
using Lease.Domain;
using Lease.Infrastructure.Shared;
using Lease.Domain.InterFace;

namespace Lease.Infrastructure.Lease
{
    public class LeaseRepository : ILeaseRepository, IDisposable
    {
        private readonly LeaseDbContext _dbContext;

        public LeaseRepository(LeaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        //LeaseOrder
        public async Task AddLeaseOrder(LeaseOrder entity)
            => await _dbContext.Leases.AddAsync(entity);

        public async Task<bool> LeaseOrderExists(LeaseId id) 
            => await _dbContext.Leases.FindAsync(id.Value) != null;

        
        public async Task<LeaseOrder> LoadLeaseOrder(LeaseId id)
            => await _dbContext.Leases.FindAsync(id.Value);

        //leaseOrderLine
        //public async Task AddLeaseOrderLine(LeaseOrderLine entity)
        //    => await _dbContext.Leases.AddAsync(entity);

        public async Task<bool> LeaseOrderLineExists(LeaseOrderLineId id)
            => await _dbContext.Leases.FindAsync(id.Value) != null;


        public async Task<LeaseOrder> LoadLeaseOrderLine(LeaseOrderLineId id)
            => await _dbContext.Leases.FindAsync(id.Value);

    }
}