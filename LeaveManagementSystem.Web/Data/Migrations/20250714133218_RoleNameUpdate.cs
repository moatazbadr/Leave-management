using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoleNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d852735f-e5bf-45d4-89ae-a1737e959552",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "supervisor", "SUPERVISOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0156d175-d3f1-49c9-9433-6460497ebaf1", "AQAAAAIAAYagAAAAEHUIepCnU5hhDrMnNNaBPI7izZiNqXr4RKiwkeYb7dSowdPf571T5p2Jh9HKBbt9Cg==", "555e540b-f4cb-4517-bf01-776bbe6b61aa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d852735f-e5bf-45d4-89ae-a1737e959552",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf5ce94c-e13a-45a5-90d2-5acc6ea17ae6", "AQAAAAIAAYagAAAAEJeUoQdR7/zpxlLh/1yiqwF3o2eBU03VFI2NP5x1J1uvkiqm8ubxFGrb57bbM11Dng==", "14faace9-43c9-4939-acac-793a5fe9b07b" });
        }
    }
}
