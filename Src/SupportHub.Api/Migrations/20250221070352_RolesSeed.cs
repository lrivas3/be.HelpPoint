using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupportHub.Api.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13220bbd-ad87-45b0-b8c7-003ad3f25de3", null, "SupportStaff", "SUPPORTSTAFF" },
                    { "2442a44f-7e38-40cf-83f5-dddeb28af17e", null, "Admin", "ADMIN" },
                    { "2b1031e9-209c-43ba-9838-240a565c28e6", null, "AreaManager", "AREAMANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13220bbd-ad87-45b0-b8c7-003ad3f25de3");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2442a44f-7e38-40cf-83f5-dddeb28af17e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b1031e9-209c-43ba-9838-240a565c28e6");
        }
    }
}
