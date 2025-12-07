using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matgr.OrdersAPI.OrdersAPIData.migrations
{
    public partial class addPaymentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PaymentStatus",
                table: "OrderHeaders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "OrderHeaders");
        }
    }
}
