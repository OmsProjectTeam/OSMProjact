using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class Cityedite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CurrentState",
                table: "cities",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<string>(
                name: "DataEntry",
                table: "cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeEntry",
                table: "cities",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "DataEntry",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "DateTimeEntry",
                table: "cities");
        }
    }
}
