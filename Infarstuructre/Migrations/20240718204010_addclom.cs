using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class addclom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "TBConnectAndDisConnects",
                columns: table => new
                {
                    IdConnectAndDisConnect = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),


                    ConnectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserImg = table.Column<string>(type: "nvarchar(max)", nullable: false),

                  
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBConnectAndDisConnects", x => x.IdConnectAndDisConnect);
                });

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBSupportTickets");

            migrationBuilder.DropTable(
                name: "TBSupportTicketStatuss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBConnectAndDisConnects",
                table: "TBConnectAndDisConnects");

            migrationBuilder.DropColumn(
                name: "note",
                table: "TBConnectAndDisConnects");

            migrationBuilder.AlterColumn<int>(
                name: "IdConnectAndDisConnect",
                table: "TBConnectAndDisConnects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
