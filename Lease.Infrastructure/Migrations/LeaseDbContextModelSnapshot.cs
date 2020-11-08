﻿// <auto-generated />
using System;
using Lease.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lease.Infrastructure.Migrations
{
    [DbContext(typeof(LeaseDbContext))]
    partial class LeaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lease.Domain.LeaseOrder", b =>
                {
                    b.Property<Guid>("leaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("leaseId");

                    b.ToTable("Leases");
                });

            modelBuilder.Entity("Lease.Domain.LeaseOrderLine", b =>
                {
                    b.Property<Guid>("LeaseOrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LeaseOrderleaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("LeaseOrderLineId");

                    b.HasIndex("LeaseOrderleaseId");

                    b.ToTable("LeaseOrderLine");
                });

            modelBuilder.Entity("Lease.Domain.LeaseOrder", b =>
                {
                    b.OwnsOne("Lease.Domain.City", "City", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderleaseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LeaseOrderleaseId");

                            b1.ToTable("Leases");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderleaseId");
                        });

                    b.OwnsOne("Lease.Domain.DateCreated", "DateCreated", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderleaseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2");

                            b1.HasKey("LeaseOrderleaseId");

                            b1.ToTable("Leases");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderleaseId");
                        });

                    b.OwnsOne("Lease.Domain.IsDeleted", "IsDeleted", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderleaseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("LeaseOrderleaseId");

                            b1.ToTable("Leases");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderleaseId");
                        });

                    b.OwnsOne("Lease.Domain.IsDelivery", "IsDelivery", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderleaseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("LeaseOrderleaseId");

                            b1.ToTable("Leases");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderleaseId");
                        });

                    b.OwnsOne("Lease.Domain.IsPaid", "IsPaid", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderleaseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("LeaseOrderleaseId");

                            b1.ToTable("Leases");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderleaseId");
                        });

                    b.OwnsOne("Lease.Domain.LeaseOrderId", "Id", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderleaseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("LeaseOrderleaseId");

                            b1.ToTable("Leases");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderleaseId");
                        });

                    b.OwnsOne("Lease.Domain.Street", "Street", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderleaseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LeaseOrderleaseId");

                            b1.ToTable("Leases");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderleaseId");
                        });

                    b.OwnsOne("Lease.Domain.TotalPrice", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderleaseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("LeaseOrderleaseId");

                            b1.ToTable("Leases");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderleaseId");
                        });

                    b.OwnsOne("Lease.Domain.ZipCode", "ZipCode", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderleaseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("LeaseOrderleaseId");

                            b1.ToTable("Leases");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderleaseId");
                        });
                });

            modelBuilder.Entity("Lease.Domain.LeaseOrderLine", b =>
                {
                    b.HasOne("Lease.Domain.LeaseOrder", null)
                        .WithMany("LeaseOrderLines")
                        .HasForeignKey("LeaseOrderleaseId");

                    b.OwnsOne("Lease.Domain.EndDate", "EndDate", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2");

                            b1.HasKey("LeaseOrderLineId");

                            b1.ToTable("LeaseOrderLine");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderLineId");
                        });

                    b.OwnsOne("Lease.Domain.IsReturned", "IsReturned", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("LeaseOrderLineId");

                            b1.ToTable("LeaseOrderLine");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderLineId");
                        });

                    b.OwnsOne("Lease.Domain.LeaseOrderId", "ParentId", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("LeaseOrderLineId");

                            b1.ToTable("LeaseOrderLine");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderLineId");
                        });

                    b.OwnsOne("Lease.Domain.LeaseOrderLineId", "Id", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("LeaseOrderLineId");

                            b1.ToTable("LeaseOrderLine");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderLineId");
                        });

                    b.OwnsOne("Lease.Domain.LineTotalPrice", "LineTotalPrice", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("LeaseOrderLineId");

                            b1.ToTable("LeaseOrderLine");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderLineId");
                        });

                    b.OwnsOne("Lease.Domain.Quantity", "Quantity", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("LeaseOrderLineId");

                            b1.ToTable("LeaseOrderLine");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderLineId");
                        });

                    b.OwnsOne("Lease.Domain.RessourceName", "RessourceName", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LeaseOrderLineId");

                            b1.ToTable("LeaseOrderLine");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderLineId");
                        });

                    b.OwnsOne("Lease.Domain.RessourcePrice", "RessourcePrice", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("LeaseOrderLineId");

                            b1.ToTable("LeaseOrderLine");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderLineId");
                        });

                    b.OwnsOne("Lease.Domain.StartDate", "StartDate", b1 =>
                        {
                            b1.Property<Guid>("LeaseOrderLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2");

                            b1.HasKey("LeaseOrderLineId");

                            b1.ToTable("LeaseOrderLine");

                            b1.WithOwner()
                                .HasForeignKey("LeaseOrderLineId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
