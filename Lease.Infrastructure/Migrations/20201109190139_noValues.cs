using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lease.Infrastructure.Migrations
{
    public partial class noValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "CustomerId_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "DateCreated_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "IsDeleted_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "IsDelivery_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "IsPaid_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "Street_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "TotalPrice_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "ZipCode_Value",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "EndDate_Value",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "IsReturned_Value",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "LineTotalPrice_Value",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "Quantity_Value",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "RessourceName_Value",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "RessourcePrice_Value",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "StartDate_Value",
                table: "LeaseOrderLines");

            migrationBuilder.RenameColumn(
                name: "ParentId_Value",
                table: "LeaseOrderLines",
                newName: "Id_Value");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Leases",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Leases",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Leases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Leases",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelivery",
                table: "Leases",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Leases",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Leases",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Leases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Leases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "LeaseOrderLines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "LeaseOrderLines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LeaseId",
                table: "LeaseOrderLines",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LineTotalPrice",
                table: "LeaseOrderLines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "LeaseOrderLines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RessourceName",
                table: "LeaseOrderLines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RessourcePrice",
                table: "LeaseOrderLines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "LeaseOrderLines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "IsDelivery",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "LeaseId",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "LineTotalPrice",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "RessourceName",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "RessourcePrice",
                table: "LeaseOrderLines");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "LeaseOrderLines");

            migrationBuilder.RenameColumn(
                name: "Id_Value",
                table: "LeaseOrderLines",
                newName: "ParentId_Value");

            migrationBuilder.AddColumn<string>(
                name: "City_Value",
                table: "Leases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId_Value",
                table: "Leases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated_Value",
                table: "Leases",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted_Value",
                table: "Leases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelivery_Value",
                table: "Leases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid_Value",
                table: "Leases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street_Value",
                table: "Leases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice_Value",
                table: "Leases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode_Value",
                table: "Leases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate_Value",
                table: "LeaseOrderLines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned_Value",
                table: "LeaseOrderLines",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineTotalPrice_Value",
                table: "LeaseOrderLines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity_Value",
                table: "LeaseOrderLines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RessourceName_Value",
                table: "LeaseOrderLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RessourcePrice_Value",
                table: "LeaseOrderLines",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate_Value",
                table: "LeaseOrderLines",
                type: "datetime2",
                nullable: true);
        }
    }
}
