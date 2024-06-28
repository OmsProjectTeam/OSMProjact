using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class updatecompny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdArea",
                table: "TBInformationCompaniess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCitu",
                table: "TBInformationCompaniess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdUserIdentity",
                table: "TBInformationCompaniess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdArea",
                table: "TBInformationCompaniess");

            migrationBuilder.DropColumn(
                name: "IdCitu",
                table: "TBInformationCompaniess");

            migrationBuilder.DropColumn(
                name: "IdUserIdentity",
                table: "TBInformationCompaniess");
        }
    }
}
