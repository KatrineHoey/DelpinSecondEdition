using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lease.Infrastructure
{
    public interface ILeaseDbContext
    {
        void Configure(EntityTypeBuilder<Domain.Lease> builder);
    }
}