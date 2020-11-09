using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lease.Infrastructure.Migrations
{
    public partial class CustomerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Value",
                table: "LeaseOrderLines");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId_Value",
                table: "Leases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId_Value",
                table: "Leases");

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Value",
                table: "LeaseOrderLines",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
