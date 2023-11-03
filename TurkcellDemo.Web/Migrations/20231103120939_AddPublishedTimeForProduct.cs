using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurkcellDemo.Web.Migrations
{
    public partial class AddPublishedTimeForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedTime",
                table: "Products",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishedTime",
                table: "Products");
        }
    }
}
