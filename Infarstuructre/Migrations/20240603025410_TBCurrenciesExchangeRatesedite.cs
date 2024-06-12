using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBCurrenciesExchangeRatesedite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlackMarketExchangeRate",
                table: "TBCurrenciesExchangeRatess");

            migrationBuilder.DropColumn(
                name: "ForeignCurrency",
                table: "TBCurrenciesExchangeRatess");

            migrationBuilder.DropColumn(
                name: "GlobalExchangeRate",
                table: "TBCurrenciesExchangeRatess");

            migrationBuilder.DropColumn(
                name: "localCurrency",
                table: "TBCurrenciesExchangeRatess");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlackMarketExchangeRate",
                table: "TBCurrenciesExchangeRatess",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForeignCurrency",
                table: "TBCurrenciesExchangeRatess",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GlobalExchangeRate",
                table: "TBCurrenciesExchangeRatess",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localCurrency",
                table: "TBCurrenciesExchangeRatess",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
