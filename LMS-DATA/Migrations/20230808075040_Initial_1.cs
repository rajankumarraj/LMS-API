using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.DATA.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00ac5301-8de5-4db0-bfcd-d509e4906a4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4c6a61a-0355-4f59-9048-fd1fc9a38610");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6921b8a5-4218-41d3-8da4-1adc386a2b5d", null, "Administrator", "ADMINISTRATOR" },
                    { "c5b038f2-3b8a-4668-94a9-92f033eeb8d7", null, "Visitor", "VISITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6921b8a5-4218-41d3-8da4-1adc386a2b5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5b038f2-3b8a-4668-94a9-92f033eeb8d7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00ac5301-8de5-4db0-bfcd-d509e4906a4e", null, "Visitor", "VISITOR" },
                    { "d4c6a61a-0355-4f59-9048-fd1fc9a38610", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
