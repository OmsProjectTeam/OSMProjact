using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class addNewsLetterTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBEmailNewsletters",
                columns: table => new
                {
                    IdEmailNewsletter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsSubscribed = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DateEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBEmailNewsletters", x => x.IdEmailNewsletter);
                });

            migrationBuilder.CreateTable(
                name: "TBNewsLetterSenders",
                columns: table => new
                {
                    IdNewsLetterSender = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmailNewsletter = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AdsHtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateSend = table.Column<DateOnly>(type: "date", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DateEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBNewsLetterSenders", x => x.IdNewsLetterSender);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBEmailNewsletters");

            migrationBuilder.DropTable(
                name: "TBNewsLetterSenders");
        }
    }
}
