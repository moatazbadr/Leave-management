using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTablesANDRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "leaveAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaveAllocations_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaveAllocations_leaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "leaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaveAllocations_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffc5a02d-8749-4fc8-8623-ce772f7fb314", "AQAAAAIAAYagAAAAEJJTRvFOXos3l4A7i2OEI8pVl55h9rPDi39pubNbZY+41c+NhH36e52wlp5IAZkNig==", "884ba8cc-701f-41a5-b0b1-43030a0effef" });

            migrationBuilder.CreateIndex(
                name: "IX_leaveAllocations_EmployeeId",
                table: "leaveAllocations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveAllocations_LeaveTypeId",
                table: "leaveAllocations",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveAllocations_PeriodId",
                table: "leaveAllocations",
                column: "PeriodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaveAllocations");

            migrationBuilder.DropTable(
                name: "periods");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "828f4b15-147c-4212-ad27-e55f818b209a", "AQAAAAIAAYagAAAAEPMTYmAleWYleMsryFUPRiSkBdzYgGWu2T3N3d+srF9W9U8WlZxP67pxOXGAtqD6ZQ==", "153e8965-a2d5-4bb6-91a5-020289b69c07" });
        }
    }
}
