using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBAreaDeliveryTariffsAndTBCityDeliveryTariffs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAreaDeliveryTariffss",
                columns: table => new
                {
                    IdAreaDeliveryTariffs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    IdInformationCompanies = table.Column<int>(type: "int", nullable: false),
                    IdCurrenciesExchangeRates = table.Column<int>(type: "int", nullable: false),
                    TitleShipping = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CompanyDelivery = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ClintDelivery = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAreaDeliveryTariffss", x => x.IdAreaDeliveryTariffs);
                });

            migrationBuilder.CreateTable(
                name: "TBCityDeliveryTariffss",
                columns: table => new
                {
                    IdCityDeliveryTariffs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IdInformationCompanies = table.Column<int>(type: "int", nullable: false),
                    IdCurrenciesExchangeRates = table.Column<int>(type: "int", nullable: false),
                    TitleShipping = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CompanyDelivery = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ClintDelivery = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCityDeliveryTariffss", x => x.IdCityDeliveryTariffs);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAreaDeliveryTariffss");

            migrationBuilder.DropTable(
                name: "TBCityDeliveryTariffss");
        }
    }
}
