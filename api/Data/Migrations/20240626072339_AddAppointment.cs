using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54d2f413-3f38-48c5-a4ba-a8592d70998b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b12ee16-ca0d-4950-92cd-b56a0e710380");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adeabf68-a227-46e1-b18f-9f8c52f31ce4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpertId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23359a62-3c30-46c8-bec1-d0fdbefab63a", null, "Admin", "ADMIN" },
                    { "443baa78-5249-4535-83f9-fbf4bd89912a", null, "User", "USER" },
                    { "c38bb702-c443-4030-be33-7884ab7eccb3", null, "Expert", "EXPERT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ExpertId",
                table: "Appointments",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54d2f413-3f38-48c5-a4ba-a8592d70998b", null, "User", "USER" },
                    { "8b12ee16-ca0d-4950-92cd-b56a0e710380", null, "Admin", "ADMIN" },
                    { "adeabf68-a227-46e1-b18f-9f8c52f31ce4", null, "Expert", "EXPERT" }
                });
        }
    }
}
