using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
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
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Soluta magnam consectetur sed neque magni illum numquam aliquam provident tempora reiciendis? Repellendus dolorem id provident quidem fugiat velit officia. Quisquam, assumenda. ", "ananas-blog.jpeg", false, "Qurudulmuş ananasın faydaları" },
                    { 2, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Soluta magnam consectetur sed neque magni illum numquam aliquam provident tempora reiciendis? Repellendus dolorem id provident quidem fugiat velit officia. Quisquam, assumenda. ", "alma-blog.jpeg", false, "Darçınlı alma qurusu" },
                    { 3, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Soluta magnam consectetur sed neque magni illum numquam aliquam provident tempora reiciendis? Repellendus dolorem id provident quidem fugiat velit officia. Quisquam, assumenda. ", "instagram11.jpeg", false, "Magnolia" },
                    { 4, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Soluta magnam consectetur sed neque magni illum numquam aliquam provident tempora reiciendis? Repellendus dolorem id provident quidem fugiat velit officia. Quisquam, assumenda. ", "instagram10.jpeg", false, "Lokumlar" },
                    { 5, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Soluta magnam consectetur sed neque magni illum numquam aliquam provident tempora reiciendis? Repellendus dolorem id provident quidem fugiat velit officia. Quisquam, assumenda. ", "instagram1.jpeg", false, "Çərəzlər" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
