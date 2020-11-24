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
                    BuyerId_Value = table.Column<Guid>(nullable: true),
                    BuyerId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leases", x => x.LeaseOrderId);
                    table.ForeignKey(
                        name: "FK_Leases_Buyers_BuyerId1",
                        column: x => x.BuyerId1,
                        principalTable: "Buyers",
                        principalColumn: "BuyerId",
                        onDelete: ReferentialAction.Restrict);
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
                    RessourcePrice_Value = table.Column<int>(nullable: true),
                    Quantity_Value = table.Column<int>(nullable: true),
                    LineTotalPrice_Value = table.Column<int>(nullable: true),
                    LeaseId_LeaseOrderIdValue = table.Column<Guid>(nullable: true),
                    RessourceId_Value = table.Column<Guid>(nullable: true),
                    LeaseOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseOrderLines", x => x.LeaseOrderLineId);
                    table.ForeignKey(
                        name: "FK_LeaseOrderLines_Leases_LeaseOrderId",
                        column: x => x.LeaseOrderId,
                        principalTable: "Leases",
                        principalColumn: "LeaseOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaseOrderLines_LeaseOrderId",
                table: "LeaseOrderLines",
                column: "LeaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_BuyerId1",
                table: "Leases",
                column: "BuyerId1");
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
