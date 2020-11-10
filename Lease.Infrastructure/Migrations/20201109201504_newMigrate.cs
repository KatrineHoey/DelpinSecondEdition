using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lease.Infrastructure.Migrations
{
    public partial class newMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseOrderLines_Leases_LeaseOrderleaseId",
                table: "LeaseOrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leases",
                table: "Leases");

            migrationBuilder.DropIndex(
                name: "IX_LeaseOrderLines_LeaseOrderleaseId",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "leaseId",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "Id_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "LeaseOrderleaseId",
                table: "LeaseOrderLines");

            migrationBuilder.AddColumn<Guid>(
                name: "LeaseOrderId",
                table: "Leases",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_LeaseOrderIdValue",
                table: "Leases",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leases",
                table: "Leases",
                column: "LeaseOrderId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseOrderLines_Leases_LeaseId",
                table: "LeaseOrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leases",
                table: "Leases");

            migrationBuilder.DropIndex(
                name: "IX_LeaseOrderLines_LeaseId",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "LeaseOrderId",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "Id_LeaseOrderIdValue",
                table: "Leases");

            migrationBuilder.AddColumn<Guid>(
                name: "leaseId",
                table: "Leases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Value",
                table: "Leases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeaseOrderleaseId",
                table: "LeaseOrderLines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leases",
                table: "Leases",
                column: "leaseId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseOrderLines_LeaseOrderleaseId",
                table: "LeaseOrderLines",
                column: "LeaseOrderleaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseOrderLines_Leases_LeaseOrderleaseId",
                table: "LeaseOrderLines",
                column: "LeaseOrderleaseId",
                principalTable: "Leases",
                principalColumn: "leaseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
