using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedAbout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "About",
                columns: new[] { "Id", "Description", "SoftDeleted" },
                values: new object[] { 1, "Kish-Mish is one of the newest family-owned and operated sweets entreprise in Azerbaijan. It has been making taffy, milk chocolate and dark chocolate orange sticks, and cinnamon bears for 1 year. Additionally, Kish-Mish makes an array of gourmet chocolate candies, holiday candy, sugar free candy, and nostalgic candy - an assortment ranging from chocolate covered peanut clusters to marshmallow Easter eggs and jelly beans.", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");
        }
    }
}
