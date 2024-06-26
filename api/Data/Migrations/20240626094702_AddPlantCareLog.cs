using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPlantCareLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PlantCareLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCareLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantCareLogs_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantCareLogs_AspNetUsers_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07674c2c-ee72-4789-a8a1-4df8b27b3cd0", null, "User", "USER" },
                    { "48dd1f1f-e09e-467a-bb5c-4ec5b05cfa7e", null, "Expert", "EXPERT" },
                    { "ae4352aa-bb87-4bf8-9b51-266e1825d0be", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantCareLogs_AppointmentId",
                table: "PlantCareLogs",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantCareLogs_ExpertId",
                table: "PlantCareLogs",
                column: "ExpertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantCareLogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07674c2c-ee72-4789-a8a1-4df8b27b3cd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48dd1f1f-e09e-467a-bb5c-4ec5b05cfa7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae4352aa-bb87-4bf8-9b51-266e1825d0be");

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
    }
}
