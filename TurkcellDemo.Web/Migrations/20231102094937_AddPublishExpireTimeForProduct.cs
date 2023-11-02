using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurkcellDemo.Web.Migrations
{
    public partial class AddPublishExpireTimeForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublishExpireTime",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishExpireTime",
                table: "Products");
        }
    }
}
