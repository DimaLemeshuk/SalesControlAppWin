using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addStatysColumnInSales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "groupproducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_groupproducts = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    socialNetwork = table.Column<string>(type: "enum('Instagram','Facebook','TikTok','Telegram','Viber')", nullable: false),
                    name_stores = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_suppliers = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    contacts = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: false),
                    rating = table.Column<decimal>(type: "decimal(3,2)", precision: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_products = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    price = table.Column<double>(type: "double", nullable: false),
                    availableQuantity = table.Column<int>(type: "int", nullable: false),
                    suplier_id = table.Column<int>(type: "int", nullable: false),
                    groupProducts_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "products-group",
                        column: x => x.groupProducts_id,
                        principalTable: "groupproducts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "products-suplier",
                        column: x => x.suplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "deliveries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    deliveryCost = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "deliveries-product",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    store_id = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    salesAmount = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "sales-product",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "sales-store",
                        column: x => x.store_id,
                        principalTable: "stores",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "deliveries-product_idx",
                table: "deliveries",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "products-group_idx",
                table: "products",
                column: "groupProducts_id");

            migrationBuilder.CreateIndex(
                name: "products-suplier_idx",
                table: "products",
                column: "suplier_id");

            migrationBuilder.CreateIndex(
                name: "sales-product_idx",
                table: "sales",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "sales-store_idx",
                table: "sales",
                column: "store_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliveries");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "stores");

            migrationBuilder.DropTable(
                name: "groupproducts");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
