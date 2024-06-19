using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class RolesNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CurrentState",
                table: "RolesNames",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<string>(
                name: "DataEntry",
                table: "RolesNames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeEntry",
                table: "RolesNames",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "RolesNames");

            migrationBuilder.DropColumn(
                name: "DataEntry",
                table: "RolesNames");

            migrationBuilder.DropColumn(
                name: "DateTimeEntry",
                table: "RolesNames");
        }
    }
}
