using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commers_project.Migrations
{
    /// <inheritdoc />
    public partial class eCommerce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SellerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_comfarm_pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_creadcard = table.Column<int>(type: "int", nullable: false),
                    SellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sellerphone = table.Column<int>(type: "int", nullable: false),
                    Seller_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_comfarm_pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_creadcard = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Userphone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_price = table.Column<int>(type: "int", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    SellersSellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellersSellerId",
                        column: x => x.SellersSellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
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

            migrationBuilder.CreateTable(
                name: "Users_Sellers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Sellerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Sellers", x => new { x.UserId, x.Sellerid });
                    table.ForeignKey(
                        name: "FK_Users_Sellers_Sellers_Sellerid",
                        column: x => x.Sellerid,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Sellers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "User_products",
                columns: table => new
                {
                    Userid = table.Column<int>(type: "int", nullable: false),
                    Productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_products", x => new { x.Productid, x.Userid });
                    table.ForeignKey(
                        name: "FK_User_products_Products_Productid",
                        column: x => x.Productid,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_products_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellersSellerId",
                table: "Products",
                column: "SellersSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsUsers_UsersUserId",
                table: "ProductsUsers",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SellersUsers_UsersUserId",
                table: "SellersUsers",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_products_Userid",
                table: "User_products",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Sellers_Sellerid",
                table: "Users_Sellers",
                column: "Sellerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsUsers");

            migrationBuilder.DropTable(
                name: "SellersUsers");

            migrationBuilder.DropTable(
                name: "User_products");

            migrationBuilder.DropTable(
                name: "Users_Sellers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
