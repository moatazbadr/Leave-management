using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedMigrationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf5ce94c-e13a-45a5-90d2-5acc6ea17ae6", new DateOnly(2001, 11, 20), "Admin", "User", "AQAAAAIAAYagAAAAEJeUoQdR7/zpxlLh/1yiqwF3o2eBU03VFI2NP5x1J1uvkiqm8ubxFGrb57bbM11Dng==", "14faace9-43c9-4939-acac-793a5fe9b07b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "450f0e59-a8ed-4e54-86e9-40bba52db9be", "AQAAAAIAAYagAAAAEA7BBxYTHpz6OIYsj6UK8OkLtzkdNNUkM50a0F5IhQ/5ISmOhVHXwHPwvOUQbpxTMw==", "bb5b91af-0052-4e9f-8470-0b95ed8f495c" });
        }
    }
}
