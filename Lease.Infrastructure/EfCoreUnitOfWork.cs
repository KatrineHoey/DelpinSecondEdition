using System.Threading.Tasks;
using Delpin.Framework;

namespace Lease.Infrastructure
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly LeaseDbContext _dbContext;

        public EfCoreUnitOfWork(LeaseDbContext dbContext)
            => _dbContext = dbContext;

        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}