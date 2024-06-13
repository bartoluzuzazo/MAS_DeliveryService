using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_DeliveryService.Api.Migrations
{
    /// <inheritdoc />
    public partial class Associations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_OrderItems_ItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_OrderItems_OrderItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_PackageItems_PackageItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItems_OrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItems_OrderItems",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderItems",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PackageItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderItems",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PackageItemId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ItemOrderItem",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrderItem", x => new { x.ItemId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ItemOrderItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrderItem_OrderItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderOrderItem",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrdersId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrderItem", x => new { x.OrderId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderOrderItem_OrderItems_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderItem_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrderItem_ItemsId",
                table: "ItemOrderItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderItem_OrdersId",
                table: "OrderOrderItem",
                column: "OrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemOrderItem");

            migrationBuilder.DropTable(
                name: "OrderOrderItem");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderItemId",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderItems",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Items",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderItemId",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PackageItemId",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderId",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItems",
                table: "Orders",
                column: "OrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemId",
                table: "Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderItemId",
                table: "Items",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PackageItemId",
                table: "Items",
                column: "PackageItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_OrderItems_ItemId",
                table: "Items",
                column: "ItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_OrderItems_OrderItemId",
                table: "Items",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PackageItems_PackageItemId",
                table: "Items",
                column: "PackageItemId",
                principalTable: "PackageItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItems_OrderId",
                table: "Orders",
                column: "OrderId",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItems_OrderItems",
                table: "Orders",
                column: "OrderItems",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
