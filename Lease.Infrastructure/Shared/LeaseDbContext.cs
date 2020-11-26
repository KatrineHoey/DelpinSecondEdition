using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.SqlServer;
using Lease.Domain;

namespace Lease.Infrastructure.Shared
{
    public class LeaseDbContext : DbContext 
    {
        private readonly ILoggerFactory _loggerFactory;

        public LeaseDbContext(DbContextOptions<LeaseDbContext> options,ILoggerFactory loggerFactory): base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<LeaseOrder> Leases { get; set; }

        public DbSet<LeaseOrderLine> LeaseOrderLines { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //LeaseOrder
        //    modelBuilder.Entity<LeaseOrder>()
        //        .HasOne(p => p.Buyer)
        //        .WithMany(p => p.LeaseOrders)
        //        .HasForeignKey(p => p.BuyerId);

        //    modelBuilder.Entity<LeaseOrder>()
        //        .HasKey(x => x.LeaseOrderId);

        //    modelBuilder.Entity<LeaseOrder>()
        //        .OwnsOne(x => x.Id);


        //    //LeaseOrderLine
        //    modelBuilder.Entity<LeaseOrderLine>()
        //        .HasOne(p => p.LeaseOrder)
        //        .WithMany(b => b.LeaseOrderLines)
        //        .HasForeignKey(p => p.LeaseId);

        //    modelBuilder.Entity<LeaseOrderLine>()
        //        .HasKey(x => x.LeaseOrderLineId);

        //    modelBuilder.Entity<LeaseOrderLine>()
        //        .OwnsOne(x => x.Id);

        //    //Buyer

        //    modelBuilder.Entity<Buyer>()
        //        .HasKey(x => x.BuyerId);

        //    modelBuilder.Entity<Buyer>()
        //        .OwnsOne(x => x.Id);

        //    modelBuilder.Entity<Buyer>()
        //        .OwnsOne(x => x.BuyerName);



        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LeaseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LeaseOrderLineEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerEntityTypeConfiguration());
        }
    }

    public class BuyerEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Buyer>
    {
        public void Configure(EntityTypeBuilder<Domain.Buyer> builder)
        {
            builder.HasKey(x => x.BuyerId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.BuyerName);
        }
    }

    public class LeaseEntityTypeConfiguration : IEntityTypeConfiguration<Domain.LeaseOrder>
    {
        public void Configure(EntityTypeBuilder<Domain.LeaseOrder> builder)
        {
            builder.HasOne(p => p.Buyer)
                .WithMany(p => p.LeaseOrders)
                .HasForeignKey(p => p.BuyerId);

            builder.HasKey(x => x.LeaseOrderId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.Street);
            builder.OwnsOne(x => x.ZipCode);
            builder.OwnsOne(x => x.City);
            builder.OwnsOne(x => x.DateCreated);
            builder.OwnsOne(x => x.IsDeleted);
            builder.OwnsOne(x => x.IsDelivery);
            builder.OwnsOne(x => x.IsPaid);
            builder.OwnsOne(x => x.TotalPrice);
            //builder.OwnsOne(x => x.BuyerId);
        }
    }

    public class LeaseOrderLineEntityTypeConfiguration : IEntityTypeConfiguration<Domain.LeaseOrderLine>
    {
        public void Configure(EntityTypeBuilder<Domain.LeaseOrderLine> builder)
        {
            builder.HasOne(p => p.LeaseOrder)
           .WithMany(b => b.LeaseOrderLines)
           .HasForeignKey(p => p.LeaseId);

            builder.HasKey(x => x.LeaseOrderLineId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.StartDate);
            builder.OwnsOne(x => x.EndDate);
            builder.OwnsOne(x => x.IsReturned);
            builder.OwnsOne(x => x.ResourceId);
            builder.OwnsOne(x => x.ResourceName);
            builder.OwnsOne(x => x.ResourcePrice);
            builder.OwnsOne(x => x.Quantity);
            builder.OwnsOne(x => x.LineTotalPrice);
            //builder.OwnsOne(x => x.LeaseId);
        }
    }
}