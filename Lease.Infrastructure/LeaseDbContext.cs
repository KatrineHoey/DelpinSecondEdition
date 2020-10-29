using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lease.Infrastructure
{
    public class LeaseDbContext : DbContext, ILeaseDbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public LeaseDbContext(DbContextOptions<LeaseDbContext> options,ILoggerFactory loggerFactory): base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Domain.Lease> Leases { get; set; }

        public void Configure(EntityTypeBuilder<Domain.Lease> builder)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LeaseEntityTypeConfiguration());
        }
    }

    public class LeaseEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Lease>, ILeaseDbContext
    {
        public void Configure(EntityTypeBuilder<Domain.Lease> builder)
        {
            builder.HasKey(x => x.leaseId);
            builder.OwnsOne(x => x.Id);
            //builder.HasNoKey(x => x.Adresse);
            //builder.OwnsOne(x => x.DateCreated);
            //builder.OwnsOne(x => x.IsDeleted);
            //builder.OwnsOne(x => x.IsDelivery);
            //builder.OwnsOne(x => x.IsPaid);
            //builder.OwnsOne(x => x.TotalPrice);

        }
    }
}