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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsDelivery = table.Column<bool>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
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
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsReturned = table.Column<bool>(nullable: false),
                    RessourceName = table.Column<string>(nullable: true),
                    RessourcePrice = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    LineTotalPrice = table.Column<int>(nullable: false),
                    LeaseId = table.Column<Guid>(nullable: false),
                    RessourceId = table.Column<Guid>(nullable: false)
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
