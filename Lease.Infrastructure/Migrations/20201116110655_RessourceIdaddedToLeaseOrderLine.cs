using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lease.Infrastructure.Migrations
{
    public partial class RessourceIdaddedToLeaseOrderLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RessourceId",
                table: "LeaseOrderLines",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RessourceId",
                table: "LeaseOrderLines");
        }
    }
}
