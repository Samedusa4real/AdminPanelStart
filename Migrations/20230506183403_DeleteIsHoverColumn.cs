using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PustokTemplate.Migrations
{
    public partial class DeleteIsHoverColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHover",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHover",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
