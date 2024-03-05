using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNamesOnProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductAmount",
                table: "ShoppingCartProducts",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ProductQuantity",
                table: "Products",
                newName: "StockQuantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ShoppingCartProducts",
                newName: "ProductAmount");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Products",
                newName: "ProductQuantity");
        }
    }
}
