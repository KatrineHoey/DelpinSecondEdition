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
        

        //Der er addet Async og await til denne Task (Ikke sikkert det er rigigt)
        public async Task Add(Domain.Lease entity) 
            =>  await _dbContext.Leases.AddAsync(entity);

        public async Task<bool> Exists(LeaseId id) 
            => await _dbContext.Leases.FindAsync(id.Value) != null;

        //Der er addet Async og await til denne Task (Ikke sikkert det er rigigt)
        public async Task<Domain.Lease> Load(LeaseId id)
            => await _dbContext.Leases.FindAsync(id.Value);

        public void Dispose() => _dbContext.Dispose();
    }
}