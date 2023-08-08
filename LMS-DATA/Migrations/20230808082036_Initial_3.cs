using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.DATA.Migrations
{
    /// <inheritdoc />
    public partial class Initial_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0923a81b-91b6-40b5-9e74-6927a1bd372e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa85e3db-8d14-4227-a3c7-3c09ea301d0a");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Company",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cf288dc-35e6-4da2-9777-9ec1d4daf11b", null, "Visitor", "VISITOR" },
                    { "631e240e-bb39-4a13-8291-8a097a2a21fa", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf288dc-35e6-4da2-9777-9ec1d4daf11b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "631e240e-bb39-4a13-8291-8a097a2a21fa");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Company",
                type: "nvarchar(256)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0923a81b-91b6-40b5-9e74-6927a1bd372e", null, "Visitor", "VISITOR" },
                    { "aa85e3db-8d14-4227-a3c7-3c09ea301d0a", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
