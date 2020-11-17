using System;
using System.Threading.Tasks;
using Lease.Domain;
using Lease.Infrastructure.Shared;
using System.Security.Cryptography.X509Certificates;
using Lease.Application;

namespace Lease.Intrastructure
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

        public async Task<bool> LeaseOrderExists(Guid id) 
            => await _dbContext.Leases.FindAsync(id) != null;

        
        public async Task<LeaseOrder> LoadLeaseOrder(Guid id)
            => await _dbContext.Leases.FindAsync(id);

        ////leaseOrderLine
        public async Task AddLeaseOrderLine(LeaseOrderLine entity)
            => await _dbContext.LeaseOrderLines.AddAsync(entity);

        public async Task<bool> LeaseOrderLineExists(Guid id)
            => await _dbContext.LeaseOrderLines.FindAsync(id) != null;


        public async Task<LeaseOrderLine> LoadLeaseOrderLine(Guid id)
            => await _dbContext.LeaseOrderLines.FindAsync(id);

        public async Task DeleteLeaseOrderLine(Guid id)
        {
            var line = await _dbContext.LeaseOrderLines.FindAsync(id);
              _dbContext.LeaseOrderLines.Remove(line);
        }


        //Buyer
        public async Task<Buyer> LoadBuyer(Guid id)
        {
            return await _dbContext.Buyers.FindAsync(id);
        }

        public async Task AddBuyer(Buyer entity)
        {
            await _dbContext.Buyers.AddAsync(entity);
        }

        public async Task<bool> BuyerExists(Guid id)
        {
            return await _dbContext.Buyers.FindAsync(id) != null;
        }

        public async Task DeleteBuyer(Guid id)
        {
            var buyer = await _dbContext.Buyers.FindAsync(id);
            _dbContext.Buyers.Remove(buyer);
        }
    }
}