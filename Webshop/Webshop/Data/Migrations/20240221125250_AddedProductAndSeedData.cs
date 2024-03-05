using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Webshop.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgURL", "Name", "Price", "ProductNumber", "ProductQuantity" },
                values: new object[,]
                {
                    { 1, "En god fisk.", "/images/fisk.jpg", "Fisk", 9.99m, 10001, 5 },
                    { 2, "En gurka som passar alla tillfällen.", "/images/gurka.jpg", "Gurka", 15.9m, 10002, 20 },
                    { 3, "Rymlig och mordern husvagn för hela familjen.", "/images/husvagn.jpg", "Husvagn", 59.9m, 10003, 8 },
                    { 4, "Kan innehålla spår av alkohol.", "/images/sprit.jpg", "Sprit", 999.9m, 10004, 10 },
                    { 5, "En fossil, väl omhändertagen.", "/images/kassett.jpg", "Kassett", 37.9m, 10005, 1 },
                    { 6, "Fullt funktionellt paraply, jag lovar.", "/images/paraply.jpg", "Paraply", 79.9m, 10006, 2 },
                    { 7, "En lagom stor skruvmejsel.", "/images/skruvmejsel.jpg", "Skruvmejsel", 5.9m, 10007, 10 },
                    { 8, "Du kan diska med denna, knappt använd.", "/images/diskborste.jpg", "Diskborste", 17.9m, 10008, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
