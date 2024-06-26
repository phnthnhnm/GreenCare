using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExpertService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06cb34b-692e-494b-8240-aaacb7dfbbc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eee5ad76-6696-4545-b81c-1599b8e8cd5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f598cc6c-0ffb-4e3d-a332-73d6ab6ca2d2");

            migrationBuilder.CreateTable(
                name: "ExpertServices",
                columns: table => new
                {
                    ExpertId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertServices", x => new { x.ExpertId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ExpertServices_AspNetUsers_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertServices_Services_ServiceId",
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
                    { "54d2f413-3f38-48c5-a4ba-a8592d70998b", null, "User", "USER" },
                    { "8b12ee16-ca0d-4950-92cd-b56a0e710380", null, "Admin", "ADMIN" },
                    { "adeabf68-a227-46e1-b18f-9f8c52f31ce4", null, "Expert", "EXPERT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpertServices_ServiceId",
                table: "ExpertServices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpertServices");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a06cb34b-692e-494b-8240-aaacb7dfbbc8", null, "Admin", "ADMIN" },
                    { "eee5ad76-6696-4545-b81c-1599b8e8cd5a", null, "User", "USER" },
                    { "f598cc6c-0ffb-4e3d-a332-73d6ab6ca2d2", null, "Expert", "EXPERT" }
                });
        }
    }
}
