using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commers_project.Migrations
{
    /// <inheritdoc />
    public partial class repos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sellers_SellersSellerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SellersSellerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SellersSellerId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SellerId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "SellersSellerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellersSellerId",
                table: "Products",
                column: "SellersSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sellers_SellersSellerId",
                table: "Products",
                column: "SellersSellerId",
                principalTable: "Sellers",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
