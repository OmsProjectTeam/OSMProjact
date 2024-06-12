using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class Merchantedite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Merchants",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<bool>(
                name: "CurrentState",
                table: "Merchants",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<string>(
                name: "DataEntry",
                table: "Merchants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeEntry",
                table: "Merchants",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<int>(
                name: "IdInformationCompanies",
                table: "Merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "DataEntry",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "DateTimeEntry",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "IdInformationCompanies",
                table: "Merchants");
        }
    }
}
