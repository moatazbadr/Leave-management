using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "828f4b15-147c-4212-ad27-e55f818b209a", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPMTYmAleWYleMsryFUPRiSkBdzYgGWu2T3N3d+srF9W9U8WlZxP67pxOXGAtqD6ZQ==", "153e8965-a2d5-4bb6-91a5-020289b69c07" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0156d175-d3f1-49c9-9433-6460497ebaf1", null, "AQAAAAIAAYagAAAAEHUIepCnU5hhDrMnNNaBPI7izZiNqXr4RKiwkeYb7dSowdPf571T5p2Jh9HKBbt9Cg==", "555e540b-f4cb-4517-bf01-776bbe6b61aa" });
        }
    }
}
