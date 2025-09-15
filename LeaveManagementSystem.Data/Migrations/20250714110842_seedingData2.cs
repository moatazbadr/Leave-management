using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6932460-3d1d-4aa6-afb1-9d3c27b249c3",
                column: "NormalizedName",
                value: "ADMINISTRATOR");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "450f0e59-a8ed-4e54-86e9-40bba52db9be", "AQAAAAIAAYagAAAAEA7BBxYTHpz6OIYsj6UK8OkLtzkdNNUkM50a0F5IhQ/5ISmOhVHXwHPwvOUQbpxTMw==", "bb5b91af-0052-4e9f-8470-0b95ed8f495c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6932460-3d1d-4aa6-afb1-9d3c27b249c3",
                column: "NormalizedName",
                value: "HR");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c0f83ef-cbbc-4341-a29c-4bb53f075a33", "AQAAAAIAAYagAAAAED9OxUuhrEPY44J9mzi4DCzjd/FDd8RgwVUjREz6fBGngnmEOIsN9g/gJH+IPu8Z+w==", "6664f42f-b377-40fd-a744-04a2847d634c" });
        }
    }
}
