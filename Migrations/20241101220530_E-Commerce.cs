using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commers_project.Migrations
{
    /// <inheritdoc />
    public partial class ECommerce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsUsers");

            migrationBuilder.DropTable(
                name: "SellersUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsUsers",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsUsers", x => new { x.ProductsProductId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_ProductsUsers_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsUsers_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellersUsers",
                columns: table => new
                {
                    SellersSellerId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellersUsers", x => new { x.SellersSellerId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_SellersUsers_Sellers_SellersSellerId",
                        column: x => x.SellersSellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellersUsers_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsUsers_UsersUserId",
                table: "ProductsUsers",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SellersUsers_UsersUserId",
                table: "SellersUsers",
                column: "UsersUserId");
        }
    }
}
