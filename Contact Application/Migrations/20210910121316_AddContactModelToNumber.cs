using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact_Application.Migrations
{
    public partial class AddContactModelToNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Number_Contact_UserID",
                table: "Number");

            migrationBuilder.DropIndex(
                name: "IX_Number_UserID",
                table: "Number");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Number_ContactID",
                table: "Number",
                column: "ContactID");

            migrationBuilder.AddForeignKey(
                name: "FK_Number_Contact_ContactID",
                table: "Number",
                column: "ContactID",
                principalTable: "Contact",
                principalColumn: "ContactID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Number_Contact_ContactID",
                table: "Number");

            migrationBuilder.DropIndex(
                name: "IX_Number_ContactID",
                table: "Number");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Number",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Number_UserID",
                table: "Number",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Number_Contact_UserID",
                table: "Number",
                column: "UserID",
                principalTable: "Contact",
                principalColumn: "ContactID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
