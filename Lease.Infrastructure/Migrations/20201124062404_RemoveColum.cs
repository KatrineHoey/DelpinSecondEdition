using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lease.Infrastructure.Migrations
{
    public partial class RemoveColum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseOrderLines_Leases_LeaseOrderId",
                table: "LeaseOrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Buyers_BuyerId1",
                table: "Leases");

            migrationBuilder.DropIndex(
                name: "IX_Leases_BuyerId1",
                table: "Leases");

            migrationBuilder.DropIndex(
                name: "IX_LeaseOrderLines_LeaseOrderId",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "BuyerId1",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "BuyerId_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "LeaseOrderId",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "LeaseId_LeaseOrderIdValue",
                table: "LeaseOrderLines");

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId",
                table: "Leases",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LeaseId",
                table: "LeaseOrderLines",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Leases_BuyerId",
                table: "Leases",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseOrderLines_LeaseId",
                table: "LeaseOrderLines",
                column: "LeaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseOrderLines_Leases_LeaseId",
                table: "LeaseOrderLines",
                column: "LeaseId",
                principalTable: "Leases",
                principalColumn: "LeaseOrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Buyers_BuyerId",
                table: "Leases",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "BuyerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseOrderLines_Leases_LeaseId",
                table: "LeaseOrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Buyers_BuyerId",
                table: "Leases");

            migrationBuilder.DropIndex(
                name: "IX_Leases_BuyerId",
                table: "Leases");

            migrationBuilder.DropIndex(
                name: "IX_LeaseOrderLines_LeaseId",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "LeaseId",
                table: "LeaseOrderLines");

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId1",
                table: "Leases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId_Value",
                table: "Leases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeaseOrderId",
                table: "LeaseOrderLines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeaseId_LeaseOrderIdValue",
                table: "LeaseOrderLines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leases_BuyerId1",
                table: "Leases",
                column: "BuyerId1");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseOrderLines_LeaseOrderId",
                table: "LeaseOrderLines",
                column: "LeaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseOrderLines_Leases_LeaseOrderId",
                table: "LeaseOrderLines",
                column: "LeaseOrderId",
                principalTable: "Leases",
                principalColumn: "LeaseOrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Buyers_BuyerId1",
                table: "Leases",
                column: "BuyerId1",
                principalTable: "Buyers",
                principalColumn: "BuyerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
