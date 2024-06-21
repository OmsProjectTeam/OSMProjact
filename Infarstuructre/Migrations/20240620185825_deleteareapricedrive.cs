using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class deleteareapricedrive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAreaDeliveryTariffss");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAreaDeliveryTariffss",
                columns: table => new
                {
                    IdAreaDeliveryTariffs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    ClintDelivery = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyDelivery = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IdCurrenciesExchangeRates = table.Column<int>(type: "int", nullable: false),
                    IdInformationCompanies = table.Column<int>(type: "int", nullable: false),
                    TitleShipping = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAreaDeliveryTariffss", x => x.IdAreaDeliveryTariffs);
                });
        }
    }
}
