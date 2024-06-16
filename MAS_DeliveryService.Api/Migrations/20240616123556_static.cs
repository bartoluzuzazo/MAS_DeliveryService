using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_DeliveryService.Api.Migrations
{
    /// <inheritdoc />
    public partial class @static : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageItems_Packages_PackageId",
                table: "PackageItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Orders_DeliveredInId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Orders_SentInId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_PackageItems_ItemId",
                table: "PackageItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

            migrationBuilder.RenameTable(
                name: "Packages",
                newName: "Package");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_SerialNumber",
                table: "Package",
                newName: "IX_Package_SerialNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_SentInId",
                table: "Package",
                newName: "IX_Package_SentInId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_DeliveredInId",
                table: "Package",
                newName: "IX_Package_DeliveredInId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Package",
                table: "Package",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Static",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaxWeight = table.Column<decimal>(type: "TEXT", nullable: false),
                    YearlyVacationDays = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Static", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageItems_ItemId_PackageId",
                table: "PackageItems",
                columns: new[] { "ItemId", "PackageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId_OrderId",
                table: "OrderItems",
                columns: new[] { "ItemId", "OrderId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Orders_DeliveredInId",
                table: "Package",
                column: "DeliveredInId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Orders_SentInId",
                table: "Package",
                column: "SentInId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageItems_Package_PackageId",
                table: "PackageItems",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Orders_DeliveredInId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_Orders_SentInId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageItems_Package_PackageId",
                table: "PackageItems");

            migrationBuilder.DropTable(
                name: "Static");

            migrationBuilder.DropIndex(
                name: "IX_PackageItems_ItemId_PackageId",
                table: "PackageItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ItemId_OrderId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Package",
                table: "Package");

            migrationBuilder.RenameTable(
                name: "Package",
                newName: "Packages");

            migrationBuilder.RenameIndex(
                name: "IX_Package_SerialNumber",
                table: "Packages",
                newName: "IX_Packages_SerialNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Package_SentInId",
                table: "Packages",
                newName: "IX_Packages_SentInId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_DeliveredInId",
                table: "Packages",
                newName: "IX_Packages_DeliveredInId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PackageItems_ItemId",
                table: "PackageItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageItems_Packages_PackageId",
                table: "PackageItems",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Orders_DeliveredInId",
                table: "Packages",
                column: "DeliveredInId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Orders_SentInId",
                table: "Packages",
                column: "SentInId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
