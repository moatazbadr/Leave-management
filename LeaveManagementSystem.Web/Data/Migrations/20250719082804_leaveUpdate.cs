using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class leaveUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebed3c6c-dfb2-4969-a69e-65e6acb0de78", "AQAAAAIAAYagAAAAEM6foWHmhqmBDKLDCG9pMXl09iuSkfkgjzyRcNlSiMpXllhah5ej61i/+IRU7QdaBQ==", "dec21efc-1c14-4265-936f-ace4243edad8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffc5a02d-8749-4fc8-8623-ce772f7fb314", "AQAAAAIAAYagAAAAEJJTRvFOXos3l4A7i2OEI8pVl55h9rPDi39pubNbZY+41c+NhH36e52wlp5IAZkNig==", "884ba8cc-701f-41a5-b0b1-43030a0effef" });
        }
    }
}
