using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class editeShpingPriceClint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryPriceCompany",
                table: "TBShippingAddresseClints");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryPriceCompany",
                table: "TBShippingAddresseClints",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
