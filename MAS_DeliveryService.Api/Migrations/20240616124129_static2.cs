using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_DeliveryService.Api.Migrations
{
    /// <inheritdoc />
    public partial class static2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Static",
                columns: new[] { "Id", "MaxWeight", "YearlyVacationDays" },
                values: new object[] { new Guid("d0d75b41-11ea-4cfa-820c-fc873c8cdbf2"), 35.0m, 21 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Static",
                keyColumn: "Id",
                keyValue: new Guid("d0d75b41-11ea-4cfa-820c-fc873c8cdbf2"));
        }
    }
}
