using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBPaing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPaings",
                columns: table => new
                {
                    IdPaings = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrderNew = table.Column<int>(type: "int", nullable: false),
                    ResivedMony = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptStatment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ReceiptDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPaings", x => x.IdPaings);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPaings");
        }
    }
}
