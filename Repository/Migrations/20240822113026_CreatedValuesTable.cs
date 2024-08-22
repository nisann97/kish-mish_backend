using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedValuesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 1, "Çay üçün möhtəşəm ləzzətləri bir araya topladıq", "instagram4.jpeg", false, "Vizyonumuz" });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 2, "Həm göz zövqünüzə, həm də damaq dadınıza xitab edən mükəmməl çərəzlər.", "instagram10.jpeg", false, "Missiyamız" });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[] { 3, "Tam təbii, şəkərsiz və qatqısız Süfrələrinizi bəzəyəcək ləzzət…", "instagram3.jpeg", false, "Məqsədimiz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
