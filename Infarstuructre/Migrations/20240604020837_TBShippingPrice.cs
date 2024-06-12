using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBShippingPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBShippingPrices",
                columns: table => new
                {
                    IdShipping = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTypeSystem = table.Column<int>(type: "int", nullable: false),
                    IdInformationCompanies = table.Column<int>(type: "int", nullable: false),
                    IdCurrenciesExchangeRates = table.Column<int>(type: "int", nullable: false),
                    TitleShipping = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CoPricePerkgUnder10 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    CoPricePerkgAbove10 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ClintPricePerkgUnder10 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ClintPricePerkgAbove10 = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBShippingPrices", x => x.IdShipping);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBShippingPrices");
        }
    }
}
