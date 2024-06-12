using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBViewAreasedite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CurrentState",
                table: "areas",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<string>(
                name: "DataEntry",
                table: "areas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeEntry",
                table: "areas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "areas");

            migrationBuilder.DropColumn(
                name: "DataEntry",
                table: "areas");

            migrationBuilder.DropColumn(
                name: "DateTimeEntry",
                table: "areas");
        }
    }
}
