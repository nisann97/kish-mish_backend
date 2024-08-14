using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Image", "SoftDeleted" },
                values: new object[] { 1, "slider2.png", false });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Image", "SoftDeleted" },
                values: new object[] { 2, "slider1.png", false });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Image", "SoftDeleted" },
                values: new object[] { 3, "slider4.png", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
