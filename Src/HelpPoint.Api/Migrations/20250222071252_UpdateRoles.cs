using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HelpPoint.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e977fb1-ddcd-4b82-b54c-a6f84eafc173");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a52571a-e8e2-42a4-a464-f991caff2843");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b20d4660-00fb-43b7-b360-111104f8874b");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4117a06e-5cd3-432d-9b17-560802990e41", null, "SupportStaff", "SUPPORTSTAFF" },
                    { "48e9a536-e576-40c4-981e-f70f40547b9f", null, "Admin", "ADMIN" },
                    { "c4d74121-1c31-4cbb-88be-8eb32c114bc3", null, "AreaManager", "AREAMANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4117a06e-5cd3-432d-9b17-560802990e41");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48e9a536-e576-40c4-981e-f70f40547b9f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4d74121-1c31-4cbb-88be-8eb32c114bc3");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e977fb1-ddcd-4b82-b54c-a6f84eafc173", null, "Admin", "ADMIN" },
                    { "7a52571a-e8e2-42a4-a464-f991caff2843", null, "AreaManager", "AREAMANAGER" },
                    { "b20d4660-00fb-43b7-b360-111104f8874b", null, "SupportStaff", "SUPPORTSTAFF" }
                });
        }
    }
}
