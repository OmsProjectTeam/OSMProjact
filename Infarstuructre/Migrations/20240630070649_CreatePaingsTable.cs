using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class CreatePaingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paings",
                columns: table => new
                {
                    IdPaings = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdOrderNew = table.Column<int>(type: "int", nullable: false),
                    ResivedMony = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceiptImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paings", x => x.IdPaings);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paings");
        }
    }
}
