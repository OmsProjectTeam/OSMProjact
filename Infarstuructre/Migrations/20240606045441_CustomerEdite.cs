using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class CustomerEdite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "customers",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<bool>(
                name: "CurrentState",
                table: "customers",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<string>(
                name: "DataEntry",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeEntry",
                table: "customers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<int>(
                name: "IdInformationCompanies",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "DataEntry",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "DateTimeEntry",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "IdInformationCompanies",
                table: "customers");
        }
    }
}
