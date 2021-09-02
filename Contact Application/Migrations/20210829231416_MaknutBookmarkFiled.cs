using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact_Application.Migrations
{
    public partial class MaknutBookmarkFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBookmarked",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBookmarked",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
