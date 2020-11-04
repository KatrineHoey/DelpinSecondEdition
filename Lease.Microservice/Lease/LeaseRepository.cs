using System;
using System.Threading.Tasks;
using Lease.Domain;
using Lease.Infrastructure;

namespace Lease.Microservice.Lease
{
    public class LeaseRepository : ILeaseRepository, IDisposable
    {
        private readonly LeaseDbContext _dbContext;

        public LeaseRepository(LeaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public async Task Add(LeaseOrder entity) 
            =>  await _dbContext.Leases.AddAsync(entity);

        public async Task<bool> Exists(LeaseId id) 
            => await _dbContext.Leases.FindAsync(id.Value) != null;

        
        public async Task<LeaseOrder> Load(LeaseId id)
            => await _dbContext.Leases.FindAsync(id.Value);

        public void Dispose() => _dbContext.Dispose();
    }
}