using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lease.Infrastructure
{
    public class LeaseDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public LeaseDbContext(DbContextOptions<LeaseDbContext> options,ILoggerFactory loggerFactory): base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Domain.Lease> Leases { get; set; }

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

    public class LeaseEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Lease>
    {
        public void Configure(EntityTypeBuilder<Domain.Lease> builder)
        {
            builder.HasKey(x => x.leaseId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.Adresse);
            builder.OwnsOne(x => x.DateCreated);
            builder.OwnsOne(x => x.IsDeleted);
            builder.OwnsOne(x => x.IsDelivery);
            builder.OwnsOne(x => x.IsPaid);
            builder.OwnsOne(x => x.TotalPrice);
        }
    }
}