using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54635f9d-508d-49c5-a6a2-e5d513b2b8a1", null, "employee", "EMPLOYEE" },
                    { "a6932460-3d1d-4aa6-afb1-9d3c27b249c3", null, "administrator", "HR" },
                    { "d852735f-e5bf-45d4-89ae-a1737e959552", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7", 0, "6c0f83ef-cbbc-4341-a29c-4bb53f075a33", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAIAAYagAAAAED9OxUuhrEPY44J9mzi4DCzjd/FDd8RgwVUjREz6fBGngnmEOIsN9g/gJH+IPu8Z+w==", null, false, "6664f42f-b377-40fd-a744-04a2847d634c", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a6932460-3d1d-4aa6-afb1-9d3c27b249c3", "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54635f9d-508d-49c5-a6a2-e5d513b2b8a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d852735f-e5bf-45d4-89ae-a1737e959552");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a6932460-3d1d-4aa6-afb1-9d3c27b249c3", "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6932460-3d1d-4aa6-afb1-9d3c27b249c3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7");
        }
    }
}
