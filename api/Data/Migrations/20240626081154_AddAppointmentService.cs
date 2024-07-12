using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AppointmentServices",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentServices", x => new { x.AppointmentId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_AppointmentServices_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "007a951c-2deb-4214-9311-ccb869ddab91", null, "Admin", "ADMIN" },
                    { "103b5b85-c7fe-4d1d-b385-4c4a883e1d9f", null, "Expert", "EXPERT" },
                    { "c7786059-6c3e-4b32-aa5a-ade852999dd6", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentServices_ServiceId",
                table: "AppointmentServices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentServices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "007a951c-2deb-4214-9311-ccb869ddab91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "103b5b85-c7fe-4d1d-b385-4c4a883e1d9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7786059-6c3e-4b32-aa5a-ade852999dd6");

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
    }
}
