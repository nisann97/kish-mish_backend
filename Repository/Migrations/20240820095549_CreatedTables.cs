using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, "ÇƏRƏZLƏR", false },
                    { 2, "ŞOKOLADLAR", false },
                    { 3, "MEYVƏ QURULARI", false },
                    { 4, "DUZLU TƏAMLAR", false },
                    { 5, "KISH-MISH QUTULARI", false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "Description", "Name", "Price", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, 3, 0, "", "ALTIN ÇILEK", 10.65m, false },
                    { 2, 2, 0, "", "BITTER ŞOKOLADLI DUBLE LOKUM", 9.40m, false },
                    { 3, 2, 0, "", "BADAMLI PRALIN", 10.20m, false },
                    { 4, 3, 0, "", "ALMA QURUSU DARÇINLI", 2.10m, false },
                    { 5, 3, 0, "Təbii üsul ilə qurudulmuş yüksək keyfiyyətə malik Natural Ananas Qurusu", "NATURAL ANANAS QURUSU", 12.50m, false },
                    { 6, 2, 0, "Əsl şokolad ləzzətini sizlərə yaşadacaq – Franbuazlı Trufel", "FRANBUAZLI TRUFEL", 9.30m, false },
                    { 7, 2, 0, "Əsl şokolad ləzzətini sizlərə yaşadacaq – Fındıqlı Trufel", "FINDIQLI TRUFEL", 9.30m, false },
                    { 8, 5, 0, "Kvadrat Taxta Qutu", "KVADRAT TAXTA QUTU", 416m, false }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Image", "IsMain", "ProductId", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, "slider4.png", true, 1, false },
                    { 2, "Bitter-Sokoladli-Duble-Lokum-scaled.jpg", true, 2, false },
                    { 3, "slider3.png", true, 3, false },
                    { 4, "ALMA-QURUSU-DARÇINLI.jpg", true, 4, false },
                    { 5, "Natural-Ananas-Qurusu.jpg", true, 5, false },
                    { 6, "Franbuazli-Trufel.jpg", true, 6, false },
                    { 7, "Findiqli-Trufel.jpg", true, 7, false },
                    { 8, "Kvadrat-Taxta-Qutu-1300x1300.jpg", true, 8, false },
                    { 10, "cilek2.jpg", false, 1, false },
                    { 11, "Bitter-Sokoladli-Duble-Lokum2.jpg", false, 2, false },
                    { 12, "Badamli-Pralin2.jpg", false, 3, false },
                    { 13, "alma-qurusu2.jpeg", false, 4, false },
                    { 14, "Natural-Ananas-Qurusu2.jpg", false, 5, false },
                    { 15, "Franbuazli-Trufel2.jpg", false, 6, false },
                    { 16, "Findiqli-Trufel2.jpg", false, 7, false },
                    { 17, "instagram2.jpeg", false, 8, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductId",
                table: "ProductDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
