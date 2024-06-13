using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_DeliveryService.Api.Migrations
{
    /// <inheritdoc />
    public partial class Associations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_OrderItem_ItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_OrderItem_OrderItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_PackageItem_PackageItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItem_OrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItem_OrderItems",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageItem_Items_ItemId",
                table: "PackageItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageItem_Packages_PackageId",
                table: "PackageItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageItem",
                table: "PackageItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "PackageItem",
                newName: "PackageItems");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_PackageItem_PackageId",
                table: "PackageItems",
                newName: "IX_PackageItems_PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_PackageItem_ItemId",
                table: "PackageItems",
                newName: "IX_PackageItems_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageItems",
                table: "PackageItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PackageItems_Items_ItemId",
                table: "PackageItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageItems_Packages_PackageId",
                table: "PackageItems",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_PackageItems_Items_ItemId",
                table: "PackageItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageItems_Packages_PackageId",
                table: "PackageItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageItems",
                table: "PackageItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "PackageItems",
                newName: "PackageItem");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_PackageItems_PackageId",
                table: "PackageItem",
                newName: "IX_PackageItem_PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_PackageItems_ItemId",
                table: "PackageItem",
                newName: "IX_PackageItem_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageItem",
                table: "PackageItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_OrderItem_ItemId",
                table: "Items",
                column: "ItemId",
                principalTable: "OrderItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_OrderItem_OrderItemId",
                table: "Items",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PackageItem_PackageItemId",
                table: "Items",
                column: "PackageItemId",
                principalTable: "PackageItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItem_OrderId",
                table: "Orders",
                column: "OrderId",
                principalTable: "OrderItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItem_OrderItems",
                table: "Orders",
                column: "OrderItems",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageItem_Items_ItemId",
                table: "PackageItem",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageItem_Packages_PackageId",
                table: "PackageItem",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
