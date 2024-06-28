using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClintWitheDeliveryTariffsController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCustomer",
                table: "TBClintWitheDeliveryTariffss");

            migrationBuilder.DropColumn(
                name: "IdMerchant",
                table: "TBClintWitheDeliveryTariffss");

            migrationBuilder.AddColumn<string>(
                name: "IdUserIntity",
                table: "TBClintWitheDeliveryTariffss",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nouts",
                table: "TBClintWitheDeliveryTariffss",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUserIntity",
                table: "TBClintWitheDeliveryTariffss");

            migrationBuilder.DropColumn(
                name: "Nouts",
                table: "TBClintWitheDeliveryTariffss");

            migrationBuilder.AddColumn<int>(
                name: "IdCustomer",
                table: "TBClintWitheDeliveryTariffss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMerchant",
                table: "TBClintWitheDeliveryTariffss",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
