using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBShippingAddresseClint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBShippingAddresseClints",
                columns: table => new
                {
                    IdShippingAddresseClint = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: false),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    IdShippingPrices = table.Column<int>(type: "int", nullable: false),
                    IdCurrenciesExchangeRates = table.Column<int>(type: "int", nullable: false),
                    NearestLandmark = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ClintPricePerkgUnder10 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClintPricePerkgAbove10 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTypeSystemDelivery = table.Column<int>(type: "int", nullable: false),
                    IdCityDeliveryTariffs = table.Column<int>(type: "int", nullable: false),
                    DeliveryPriceCompany = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryPriceClint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBShippingAddresseClints", x => x.IdShippingAddresseClint);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBShippingAddresseClints");
        }
    }
}
