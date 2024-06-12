using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBCurrenciesExchangeRates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCurrenciesExchangeRatess",
                columns: table => new
                {
                    IdCurrenciesExchangeRates = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    localCurrency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ForeignCurrency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GlobalExchangeRate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BlackMarketExchangeRate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCurrenciesExchangeRatess", x => x.IdCurrenciesExchangeRates);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCurrenciesExchangeRatess");
        }
    }
}
