using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAppointmentDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23359a62-3c30-46c8-bec1-d0fdbefab63a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "443baa78-5249-4535-83f9-fbf4bd89912a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c38bb702-c443-4030-be33-7884ab7eccb3");

            migrationBuilder.RenameColumn(
                name: "AppointmentDateTime",
                table: "Appointments",
                newName: "DateTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76c5f7f5-608e-45ab-8224-c79b7c32fa7d", null, "Admin", "ADMIN" },
                    { "a9305c88-65bf-4e33-b56f-305de8cc1b97", null, "Expert", "EXPERT" },
                    { "ccd2fd30-da03-4088-ab3a-f5c05988a2b0", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76c5f7f5-608e-45ab-8224-c79b7c32fa7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9305c88-65bf-4e33-b56f-305de8cc1b97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccd2fd30-da03-4088-ab3a-f5c05988a2b0");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Appointments",
                newName: "AppointmentDateTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23359a62-3c30-46c8-bec1-d0fdbefab63a", null, "Admin", "ADMIN" },
                    { "443baa78-5249-4535-83f9-fbf4bd89912a", null, "User", "USER" },
                    { "c38bb702-c443-4030-be33-7884ab7eccb3", null, "Expert", "EXPERT" }
                });
        }
    }
}
