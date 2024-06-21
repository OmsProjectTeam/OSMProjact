using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class updateTBCityDeliveryTariffs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "TBCityDeliveryTariffss",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TBCityDeliveryTariffss",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "TBCityDeliveryTariffss",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTypeSystemDelivery",
                table: "TBCityDeliveryTariffss",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TBCityDeliveryTariffss");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "TBCityDeliveryTariffss");

            migrationBuilder.DropColumn(
                name: "IdTypeSystemDelivery",
                table: "TBCityDeliveryTariffss");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "TBCityDeliveryTariffss",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
