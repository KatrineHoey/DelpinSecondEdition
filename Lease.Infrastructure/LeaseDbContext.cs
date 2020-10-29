using Lease.Domain;
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

        public DbSet<Domain.Lease> Lease { get; set; }

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
            //builder.HasKey(x => x.LeaseId);
            //builder.OwnsOne(x => x.Id);
            //builder.OwnsOne(x => x.Price, p => p.OwnsOne(c => c.Currency));
            //builder.OwnsOne(x => x.Text);
            //builder.OwnsOne(x => x.Title);
            //builder.OwnsOne(x => x.ApprovedBy);
            //builder.OwnsOne(x => x.OwnerId);
        }
    }

    

    
}