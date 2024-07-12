using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Services_ServiceId",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpertServices_AspNetUsers_ExpertId",
                table: "ExpertServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpertServices_Services_ServiceId",
                table: "ExpertServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantTypeServices_PlantTypes_PlantTypeId",
                table: "PlantTypeServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantTypeServices_Services_ServiceId",
                table: "PlantTypeServices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "737248a1-43ab-43d8-b1a5-0cfe15bbc8f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e2e5631-f79b-437b-a53f-2c06a3648275");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5739da9-0156-4753-85e1-e4dbef996415");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0890ec53-13dc-4559-8b52-2d5a41dcc4af", null, "Expert", "EXPERT" },
                    { "d1af400e-66b1-4436-b3b2-af5e243c7635", null, "Admin", "ADMIN" },
                    { "f6e65785-dcf3-498e-bc2e-e921bd895133", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ServiceId",
                table: "Reviews",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Services_ServiceId",
                table: "AppointmentServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertServices_AspNetUsers_ExpertId",
                table: "ExpertServices",
                column: "ExpertId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertServices_Services_ServiceId",
                table: "ExpertServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantTypeServices_PlantTypes_PlantTypeId",
                table: "PlantTypeServices",
                column: "PlantTypeId",
                principalTable: "PlantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantTypeServices_Services_ServiceId",
                table: "PlantTypeServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Services_ServiceId",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpertServices_AspNetUsers_ExpertId",
                table: "ExpertServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpertServices_Services_ServiceId",
                table: "ExpertServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantTypeServices_PlantTypes_PlantTypeId",
                table: "PlantTypeServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantTypeServices_Services_ServiceId",
                table: "PlantTypeServices");

            migrationBuilder.DropTable(
                name: "Reviews");

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
                    { "737248a1-43ab-43d8-b1a5-0cfe15bbc8f3", null, "User", "USER" },
                    { "8e2e5631-f79b-437b-a53f-2c06a3648275", null, "Expert", "EXPERT" },
                    { "b5739da9-0156-4753-85e1-e4dbef996415", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Services_ServiceId",
                table: "AppointmentServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertServices_AspNetUsers_ExpertId",
                table: "ExpertServices",
                column: "ExpertId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertServices_Services_ServiceId",
                table: "ExpertServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantTypeServices_PlantTypes_PlantTypeId",
                table: "PlantTypeServices",
                column: "PlantTypeId",
                principalTable: "PlantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantTypeServices_Services_ServiceId",
                table: "PlantTypeServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
