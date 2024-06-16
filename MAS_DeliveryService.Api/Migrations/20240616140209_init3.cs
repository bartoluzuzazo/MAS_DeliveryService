using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MAS_DeliveryService.Api.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DriversLicenseId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriversLicenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateIssued = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Categories = table.Column<string>(type: "TEXT", nullable: false),
                    CourierId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriversLicenses_Courier_CourierId",
                        column: x => x.CourierId,
                        principalTable: "Courier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateTo = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CourierId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Courier_CourierId",
                        column: x => x.CourierId,
                        principalTable: "Courier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Sender = table.Column<string>(type: "TEXT", nullable: false),
                    Destination = table.Column<string>(type: "TEXT", nullable: false),
                    IsCancelled = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    SentInId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeliveredInId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_Orders_DeliveredInId",
                        column: x => x.DeliveredInId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Package_Orders_SentInId",
                        column: x => x.SentInId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PackageId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageItems_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Education = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: true),
                    WorkerId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<int>(type: "INTEGER", nullable: false),
                    SalaryPerHour = table.Column<decimal>(type: "TEXT", nullable: true),
                    MonthlySalary = table.Column<decimal>(type: "TEXT", nullable: true),
                    VacationDaysLeft = table.Column<int>(type: "INTEGER", nullable: true),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worker_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("0cbb1178-ff27-4e05-a01b-94ebcd75a1b1"), "Water bottle", 1.0m },
                    { new Guid("51568137-dabd-437f-aca0-55d5176e44ca"), "Pen", 0.1m },
                    { new Guid("af584438-575e-4c97-b429-128f72c2469c"), "Asbestos", 10.0m },
                    { new Guid("b97aac37-3e37-418b-bd84-b4a7c222b3fe"), "Bricks", 34.7m }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "ClientId", "FirstName", "LastName", "Number", "WorkerId" },
                values: new object[,]
                {
                    { new Guid("05be6fca-8704-4155-8e13-71b3ee56cc51"), null, "Jan", "Kowalski", "555666555", null },
                    { new Guid("7db63b89-de37-4d77-8460-bb12cb8a5ec7"), null, "John", "Marston", "555444555", null },
                    { new Guid("9126d66b-f694-4a9e-895b-6691be413b2d"), null, "Sam", "Fisher", "111222333", null },
                    { new Guid("dcf7afb1-adf7-4f16-ad38-dc5f2b214279"), null, "Nathan", "Drake", "444555666", null }
                });

            migrationBuilder.InsertData(
                table: "Static",
                columns: new[] { "Id", "MaxWeight", "YearlyVacationDays" },
                values: new object[] { new Guid("ae9513bd-965f-49fa-a075-f42fa3482eb7"), 35.0m, 21 });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "Email", "PersonId" },
                values: new object[,]
                {
                    { new Guid("1036d298-8b4c-4391-ab44-e0c54d4799aa"), "marston@gmail.com", new Guid("7db63b89-de37-4d77-8460-bb12cb8a5ec7") },
                    { new Guid("caafbfab-ce64-433a-bd37-d68169df1fa3"), "fisher@gmail.com", new Guid("9126d66b-f694-4a9e-895b-6691be413b2d") }
                });

            migrationBuilder.InsertData(
                table: "Worker",
                columns: new[] { "Id", "DateOfBirth", "Discriminator", "MonthlySalary", "PersonId", "SalaryPerHour", "VacationDaysLeft" },
                values: new object[,]
                {
                    { new Guid("11be6353-09b3-433f-99f8-564ab4baa433"), new DateTime(2024, 6, 16, 16, 2, 8, 421, DateTimeKind.Local).AddTicks(4920), 1, 5000.0m, new Guid("9126d66b-f694-4a9e-895b-6691be413b2d"), null, 0 },
                    { new Guid("2e2a8832-9b41-4651-bb6e-b889281bc89b"), new DateTime(2024, 6, 16, 16, 2, 8, 421, DateTimeKind.Local).AddTicks(5299), 1, 3500.0m, new Guid("dcf7afb1-adf7-4f16-ad38-dc5f2b214279"), null, 0 },
                    { new Guid("a781d2be-b7fb-41c5-a7d7-b5907767485a"), new DateTime(2024, 6, 16, 16, 2, 8, 421, DateTimeKind.Local).AddTicks(4854), 0, null, new Guid("05be6fca-8704-4155-8e13-71b3ee56cc51"), 30.0m, null }
                });

            migrationBuilder.InsertData(
                table: "Courier",
                columns: new[] { "Id", "DriversLicenseId" },
                values: new object[,]
                {
                    { new Guid("11be6353-09b3-433f-99f8-564ab4baa433"), null },
                    { new Guid("a781d2be-b7fb-41c5-a7d7-b5907767485a"), null }
                });

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Education" },
                values: new object[] { new Guid("2e2a8832-9b41-4651-bb6e-b889281bc89b"), "Harvard" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientId", "DeliveryId", "Destination", "IsCancelled", "Sender" },
                values: new object[,]
                {
                    { new Guid("0f1d73b7-fbdb-4b11-8e42-60f8b6864935"), new Guid("caafbfab-ce64-433a-bd37-d68169df1fa3"), null, "Example 32, Warsaw, Poland", false, "Amazon.com" },
                    { new Guid("19570230-fdad-4916-9159-7ca79ea13386"), new Guid("1036d298-8b4c-4391-ab44-e0c54d4799aa"), null, "Example 87, Warsaw, Poland", false, "Building Company" }
                });

            migrationBuilder.InsertData(
                table: "DriversLicenses",
                columns: new[] { "Id", "Categories", "CourierId", "DateIssued" },
                values: new object[] { new Guid("f9c69e34-35ee-4a11-bb40-e63d590a9b11"), "[5]", new Guid("a781d2be-b7fb-41c5-a7d7-b5907767485a"), new DateTime(2024, 6, 16, 16, 2, 8, 421, DateTimeKind.Local).AddTicks(5607) });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "ItemId", "OrderId" },
                values: new object[,]
                {
                    { new Guid("1710c85a-f034-4cf6-802d-085257631fb5"), new Guid("0cbb1178-ff27-4e05-a01b-94ebcd75a1b1"), new Guid("19570230-fdad-4916-9159-7ca79ea13386") },
                    { new Guid("53bb5537-14a5-450f-885d-e6234d84196a"), new Guid("af584438-575e-4c97-b429-128f72c2469c"), new Guid("19570230-fdad-4916-9159-7ca79ea13386") },
                    { new Guid("8b973796-44e7-49d5-909c-f8b33df8fdd2"), new Guid("b97aac37-3e37-418b-bd84-b4a7c222b3fe"), new Guid("19570230-fdad-4916-9159-7ca79ea13386") },
                    { new Guid("e0e991ff-cd16-4b88-bd93-ffe0d9361d82"), new Guid("0cbb1178-ff27-4e05-a01b-94ebcd75a1b1"), new Guid("0f1d73b7-fbdb-4b11-8e42-60f8b6864935") },
                    { new Guid("e45d0d0b-5399-4d6e-9688-ee6dcd250b32"), new Guid("51568137-dabd-437f-aca0-55d5176e44ca"), new Guid("0f1d73b7-fbdb-4b11-8e42-60f8b6864935") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_PersonId",
                table: "Client",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Courier_DriversLicenseId",
                table: "Courier",
                column: "DriversLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_CourierId_OrderId",
                table: "Deliveries",
                columns: new[] { "CourierId", "OrderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_OrderId",
                table: "Deliveries",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenses_CourierId",
                table: "DriversLicenses",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId_OrderId",
                table: "OrderItems",
                columns: new[] { "ItemId", "OrderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_DeliveredInId",
                table: "Package",
                column: "DeliveredInId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_SentInId",
                table: "Package",
                column: "SentInId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_SerialNumber",
                table: "Package",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageItems_ItemId_PackageId",
                table: "PackageItems",
                columns: new[] { "ItemId", "PackageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageItems_PackageId",
                table: "PackageItems",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ClientId",
                table: "Person",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_WorkerId",
                table: "Person",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_PersonId",
                table: "Worker",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Person_PersonId",
                table: "Client",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courier_DriversLicenses_DriversLicenseId",
                table: "Courier",
                column: "DriversLicenseId",
                principalTable: "DriversLicenses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courier_Worker_Id",
                table: "Courier",
                column: "Id",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Orders_OrderId",
                table: "Deliveries",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Worker_Id",
                table: "Manager",
                column: "Id",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Worker_WorkerId",
                table: "Person",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Person_PersonId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Person_PersonId",
                table: "Worker");

            migrationBuilder.DropForeignKey(
                name: "FK_Courier_DriversLicenses_DriversLicenseId",
                table: "Courier");

            migrationBuilder.DropForeignKey(
                name: "FK_Courier_Worker_Id",
                table: "Courier");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Courier_CourierId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Orders_OrderId",
                table: "Deliveries");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PackageItems");

            migrationBuilder.DropTable(
                name: "Static");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "DriversLicenses");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Courier");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Deliveries");
        }
    }
}
