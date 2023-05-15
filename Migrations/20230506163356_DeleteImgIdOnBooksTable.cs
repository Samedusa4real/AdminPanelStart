using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PustokTemplate.Migrations
{
    public partial class DeleteImgIdOnBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Books_BookId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_BookId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Images_BookId",
                table: "Images",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Books_BookId",
                table: "Images",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Books_BookId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_BookId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId1",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_BookId1",
                table: "Images",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Books_BookId1",
                table: "Images",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
