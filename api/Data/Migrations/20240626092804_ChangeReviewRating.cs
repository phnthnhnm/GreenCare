using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeReviewRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0890ec53-13dc-4559-8b52-2d5a41dcc4af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1af400e-66b1-4436-b3b2-af5e243c7635");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6e65785-dcf3-498e-bc2e-e921bd895133");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "071cd58d-668b-40ca-bdc7-e6f5e691ce7c", null, "User", "USER" },
                    { "3d181f6c-0c95-4f91-a9d8-d887fdf04690", null, "Expert", "EXPERT" },
                    { "5bb026b4-b3e1-49e9-9ef5-5aaf7142e3c1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "071cd58d-668b-40ca-bdc7-e6f5e691ce7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d181f6c-0c95-4f91-a9d8-d887fdf04690");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bb026b4-b3e1-49e9-9ef5-5aaf7142e3c1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0890ec53-13dc-4559-8b52-2d5a41dcc4af", null, "Expert", "EXPERT" },
                    { "d1af400e-66b1-4436-b3b2-af5e243c7635", null, "Admin", "ADMIN" },
                    { "f6e65785-dcf3-498e-bc2e-e921bd895133", null, "User", "USER" }
                });
        }
    }
}
