using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class AddDataModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MultipleProducts",
                columns: table => new
                {
                    MultipleProductId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    PairsInBox = table.Column<int>(nullable: false),
                    SizesBox = table.Column<string>(nullable: true),
                    CountBoxes = table.Column<int>(nullable: false),
                    Pairs = table.Column<int>(nullable: false),
                    PriceSale = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleProducts", x => x.MultipleProductId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeUA = table.Column<string>(nullable: true),
                    SizeUSA = table.Column<string>(nullable: true),
                    SizeEU = table.Column<string>(nullable: true),
                    SizeCM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "SingleProducts",
                columns: table => new
                {
                    SingleProductId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    PriceSale = table.Column<float>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleProducts", x => x.SingleProductId);
                    table.ForeignKey(
                        name: "FK_SingleProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SingleProducts_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SingleProducts_ProductId",
                table: "SingleProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleProducts_SizeId",
                table: "SingleProducts",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultipleProducts");

            migrationBuilder.DropTable(
                name: "SingleProducts");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
