using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Memory = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "Silver" },
                    { 3, "Space Black" },
                    { 4, "Space Grey" },
                    { 5, "Deep Purple" },
                    { 6, "Starlight" },
                    { 7, "Green" },
                    { 8, "Gold" },
                    { 9, "Sierra Blue" },
                    { 10, "Midnight" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "ColorId", "Description", "ImageUrl", "Memory", "Model", "Price" },
                values: new object[,]
                {
                    { 1, 10, "A total powerhouse.", "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone-14-finish-select-202209-6-1inch-midnight_1.png", 128, "iPhone 14", 799m },
                    { 2, 6, "Big and bigger.", "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone-14-plus_2__3.jpeg", 128, "iPhone 14 Plus", 899m },
                    { 3, 3, "The ultimate iPhone.", "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/1/4/14pro-promax-black-1_4_2.jpeg", 256, "iPhone 14 Pro", 1099m },
                    { 4, 5, "Pro. Beyond.", "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/1/4/14pro-promax-purple-1_9.jpeg", 512, "iPhone 14 Pro Max", 1399m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ColorId",
                table: "Phones",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
