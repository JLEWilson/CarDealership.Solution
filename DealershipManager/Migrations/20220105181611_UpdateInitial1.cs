using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DealershipManager.Migrations
{
    public partial class UpdateInitial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDealership_Dealerships_DealershipId1",
                table: "CarDealership");

            migrationBuilder.DropForeignKey(
                name: "FK_DealershipSalesman_Dealerships_DealershipId1",
                table: "DealershipSalesman");

            migrationBuilder.DropIndex(
                name: "IX_DealershipSalesman_DealershipId1",
                table: "DealershipSalesman");

            migrationBuilder.DropIndex(
                name: "IX_CarDealership_DealershipId1",
                table: "CarDealership");

            migrationBuilder.DropColumn(
                name: "DealershipId1",
                table: "DealershipSalesman");

            migrationBuilder.DropColumn(
                name: "DealershipId1",
                table: "CarDealership");

            migrationBuilder.AlterColumn<int>(
                name: "DealershipId",
                table: "Dealerships",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_DealershipSalesman_DealershipId",
                table: "DealershipSalesman",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDealership_DealershipId",
                table: "CarDealership",
                column: "DealershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDealership_Dealerships_DealershipId",
                table: "CarDealership",
                column: "DealershipId",
                principalTable: "Dealerships",
                principalColumn: "DealershipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DealershipSalesman_Dealerships_DealershipId",
                table: "DealershipSalesman",
                column: "DealershipId",
                principalTable: "Dealerships",
                principalColumn: "DealershipId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDealership_Dealerships_DealershipId",
                table: "CarDealership");

            migrationBuilder.DropForeignKey(
                name: "FK_DealershipSalesman_Dealerships_DealershipId",
                table: "DealershipSalesman");

            migrationBuilder.DropIndex(
                name: "IX_DealershipSalesman_DealershipId",
                table: "DealershipSalesman");

            migrationBuilder.DropIndex(
                name: "IX_CarDealership_DealershipId",
                table: "CarDealership");

            migrationBuilder.AddColumn<string>(
                name: "DealershipId1",
                table: "DealershipSalesman",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DealershipId",
                table: "Dealerships",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "DealershipId1",
                table: "CarDealership",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DealershipSalesman_DealershipId1",
                table: "DealershipSalesman",
                column: "DealershipId1");

            migrationBuilder.CreateIndex(
                name: "IX_CarDealership_DealershipId1",
                table: "CarDealership",
                column: "DealershipId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDealership_Dealerships_DealershipId1",
                table: "CarDealership",
                column: "DealershipId1",
                principalTable: "Dealerships",
                principalColumn: "DealershipId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DealershipSalesman_Dealerships_DealershipId1",
                table: "DealershipSalesman",
                column: "DealershipId1",
                principalTable: "Dealerships",
                principalColumn: "DealershipId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
