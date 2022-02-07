using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryExample.Migrations
{
    public partial class CustomerDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "SaleHeaders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "SaleHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "SaleDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "PurchaseHeaders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "PurchaseHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "PurchaseDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_ProductCode",
                table: "SaleDetails",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_ProductCode",
                table: "PurchaseDetails",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Products_ProductCode",
                table: "PurchaseDetails",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Products_ProductCode",
                table: "SaleDetails",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "ProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Products_ProductCode",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Products_ProductCode",
                table: "SaleDetails");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetails_ProductCode",
                table: "SaleDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_ProductCode",
                table: "PurchaseDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "SaleHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "SaleHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "SaleDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "PurchaseHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "PurchaseHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "PurchaseDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
