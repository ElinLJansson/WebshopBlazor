using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop.Migrations
{
    /// <inheritdoc />
    public partial class AddedDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShoppingCart_Products_ProductId",
                table: "ProductShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShoppingCart_ShoppingCart_ShoppingCartId",
                table: "ProductShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_Id",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductShoppingCart",
                table: "ProductShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ProductShoppingCart",
                newName: "ProductShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ProductShoppingCart_ShoppingCartId",
                table: "ProductShoppingCarts",
                newName: "IX_ProductShoppingCarts_ShoppingCartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductShoppingCarts",
                table: "ProductShoppingCarts",
                columns: new[] { "ProductId", "ShoppingCartId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShoppingCarts_Products_ProductId",
                table: "ProductShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "ProductShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_Id",
                table: "ShoppingCarts",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShoppingCarts_Products_ProductId",
                table: "ProductShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "ProductShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_Id",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductShoppingCarts",
                table: "ProductShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "ProductShoppingCarts",
                newName: "ProductShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_ProductShoppingCarts_ShoppingCartId",
                table: "ProductShoppingCart",
                newName: "IX_ProductShoppingCart_ShoppingCartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductShoppingCart",
                table: "ProductShoppingCart",
                columns: new[] { "ProductId", "ShoppingCartId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShoppingCart_Products_ProductId",
                table: "ProductShoppingCart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShoppingCart_ShoppingCart_ShoppingCartId",
                table: "ProductShoppingCart",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_Id",
                table: "ShoppingCart",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
