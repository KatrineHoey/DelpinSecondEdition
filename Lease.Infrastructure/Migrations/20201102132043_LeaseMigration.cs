using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lease.Infrastructure.Migrations
{
    public partial class LeaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leases",
                columns: table => new
                {
                    leaseId = table.Column<Guid>(nullable: false),
                    Id_Value = table.Column<Guid>(nullable: true),
                    DateCreated_Value = table.Column<DateTime>(nullable: true),
                    IsDeleted_Value = table.Column<bool>(nullable: true),
                    IsDelivery_Value = table.Column<bool>(nullable: true),
                    IsPaid_Value = table.Column<bool>(nullable: true),
                    TotalPrice_Value = table.Column<decimal>(nullable: true),
                    Street_Value = table.Column<string>(nullable: true),
                    ZipCode_Value = table.Column<int>(nullable: true),
                    City_Value = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leases", x => x.leaseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leases");
        }
    }
}
