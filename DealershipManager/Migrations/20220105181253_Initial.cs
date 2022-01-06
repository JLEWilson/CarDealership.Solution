using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DealershipManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Model = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Dealerships",
                columns: table => new
                {
                    DealershipId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealerships", x => x.DealershipId);
                });

            migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    SalesmanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesmen", x => x.SalesmanId);
                });

            migrationBuilder.CreateTable(
                name: "CarDealership",
                columns: table => new
                {
                    CarDealershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    DealershipId = table.Column<int>(type: "int", nullable: false),
                    DealershipId1 = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDealership", x => x.CarDealershipId);
                    table.ForeignKey(
                        name: "FK_CarDealership_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarDealership_Dealerships_DealershipId1",
                        column: x => x.DealershipId1,
                        principalTable: "Dealerships",
                        principalColumn: "DealershipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealershipSalesman",
                columns: table => new
                {
                    DealershipSalesmanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DealershipId = table.Column<int>(type: "int", nullable: false),
                    SalesmanId = table.Column<int>(type: "int", nullable: false),
                    DealershipId1 = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealershipSalesman", x => x.DealershipSalesmanId);
                    table.ForeignKey(
                        name: "FK_DealershipSalesman_Dealerships_DealershipId1",
                        column: x => x.DealershipId1,
                        principalTable: "Dealerships",
                        principalColumn: "DealershipId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DealershipSalesman_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "SalesmanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDealership_CarId",
                table: "CarDealership",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDealership_DealershipId1",
                table: "CarDealership",
                column: "DealershipId1");

            migrationBuilder.CreateIndex(
                name: "IX_DealershipSalesman_DealershipId1",
                table: "DealershipSalesman",
                column: "DealershipId1");

            migrationBuilder.CreateIndex(
                name: "IX_DealershipSalesman_SalesmanId",
                table: "DealershipSalesman",
                column: "SalesmanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDealership");

            migrationBuilder.DropTable(
                name: "DealershipSalesman");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Dealerships");

            migrationBuilder.DropTable(
                name: "Salesmen");
        }
    }
}
