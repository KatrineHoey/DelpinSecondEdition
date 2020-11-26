using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lease.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    BuyerId = table.Column<Guid>(nullable: false),
                    Id_Value = table.Column<Guid>(nullable: true),
                    BuyerName_Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.BuyerId);
                });

            migrationBuilder.CreateTable(
                name: "Leases",
                columns: table => new
                {
                    LeaseOrderId = table.Column<Guid>(nullable: false),
                    Id_LeaseOrderIdValue = table.Column<Guid>(nullable: true),
                    DateCreated_Value = table.Column<DateTime>(nullable: true),
                    IsDeleted_Value = table.Column<bool>(nullable: true),
                    IsDelivery_Value = table.Column<bool>(nullable: true),
                    IsPaid_Value = table.Column<bool>(nullable: true),
                    TotalPrice_Value = table.Column<int>(nullable: true),
                    Street_Value = table.Column<string>(nullable: true),
                    ZipCode_Value = table.Column<int>(nullable: true),
                    City_Value = table.Column<string>(nullable: true),
                    BuyerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leases", x => x.LeaseOrderId);
                    table.ForeignKey(
                        name: "FK_Leases_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "BuyerId",
                        onDelete: ReferentialAction.Cascade);
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
                    ResourceName_Value = table.Column<string>(nullable: true),
                    ResourcePrice_Value = table.Column<int>(nullable: true),
                    Quantity_Value = table.Column<int>(nullable: true),
                    LineTotalPrice_Value = table.Column<int>(nullable: true),
                    LeaseId = table.Column<Guid>(nullable: false),
                    ResourceId_Value = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseOrderLines", x => x.LeaseOrderLineId);
                    table.ForeignKey(
                        name: "FK_LeaseOrderLines_Leases_LeaseId",
                        column: x => x.LeaseId,
                        principalTable: "Leases",
                        principalColumn: "LeaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaseOrderLines_LeaseId",
                table: "LeaseOrderLines",
                column: "LeaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_BuyerId",
                table: "Leases",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaseOrderLines");

            migrationBuilder.DropTable(
                name: "Leases");

            migrationBuilder.DropTable(
                name: "Buyers");
        }
    }
}
