﻿// <auto-generated />
using System;
using Lease.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lease.Infrastructure.Migrations
{
    [DbContext(typeof(LeaseDbContext))]
    [Migration("20201116110655_RessourceIdaddedToLeaseOrderLine")]
    partial class RessourceIdaddedToLeaseOrderLine
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lease.Domain.LeaseOrder", b =>
                {
                    b.Property<Guid>("LeaseOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelivery")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("LeaseOrderId");

                    b.ToTable("Leases");
                });

            modelBuilder.Entity("Lease.Domain.LeaseOrderLine", b =>
                {
                    b.Property<Guid>("LeaseOrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<Guid>("LeaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LineTotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("RessourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RessourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RessourcePrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LeaseOrderLineId");

                    b.HasIndex("LeaseId");

                    b.ToTable("LeaseOrderLines");
                });

            modelBuilder.Entity("Lease.Domain.LeaseOrder", b =>
                {
                    b.OwnsOne("Lease.Domain.LeaseOrderId", "Id", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("LeaseOrderIdValue")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("LeaseOrderId");

                            b1.ToTable("Leases");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderId");
                        });
                });

            modelBuilder.Entity("Lease.Domain.LeaseOrderLine", b =>
                {
                    b.HasOne("Lease.Domain.LeaseOrder", "LeaseOrder")
                        .WithMany("LeaseOrderLines")
                        .HasForeignKey("LeaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Lease.Domain.LeaseOrderLineId", "Id", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("LeaseOrderLineId");

                            b1.ToTable("LeaseOrderLines");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderLineId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
