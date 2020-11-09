using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lease.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
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

            migrationBuilder.CreateTable(
                name: "LeaseOrderLines",
                columns: table => new
                {
                    LeaseOrderLineId = table.Column<Guid>(nullable: false),
                    Id_Value = table.Column<Guid>(nullable: true),
                    StartDate_Value = table.Column<DateTime>(nullable: true),
                    EndDate_Value = table.Column<DateTime>(nullable: true),
                    IsReturned_Value = table.Column<bool>(nullable: true),
                    RessourceName_Value = table.Column<string>(nullable: true),
                    RessourcePrice_Value = table.Column<decimal>(nullable: true),
                    Quantity_Value = table.Column<int>(nullable: true),
                    LineTotalPrice_Value = table.Column<decimal>(nullable: true),
                    ParentId_Value = table.Column<Guid>(nullable: true),
                    LeaseOrderleaseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseOrderLines", x => x.LeaseOrderLineId);
                    table.ForeignKey(
                        name: "FK_LeaseOrderLines_Leases_LeaseOrderleaseId",
                        column: x => x.LeaseOrderleaseId,
                        principalTable: "Leases",
                        principalColumn: "leaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaseOrderLines_LeaseOrderleaseId",
                table: "LeaseOrderLines",
                column: "LeaseOrderleaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaseOrderLines");

            migrationBuilder.DropTable(
                name: "Leases");
        }
    }
}
