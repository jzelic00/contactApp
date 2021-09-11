using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact_Application.Migrations
{
    public partial class ReplaceUserWithContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mail_User_UserID",
                table: "Mail");

            migrationBuilder.DropForeignKey(
                name: "FK_Number_User_UserID",
                table: "Number");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Mail",
                newName: "ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_Mail_UserID",
                table: "Mail",
                newName: "IX_Mail_ContactID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Number",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Number",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_Contact_Tag_TagID",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "ContactID", "Address", "LastName", "Name", "TagID" },
                values: new object[,]
                {
                    { 1, "Crikvenička 2/1", "Zelić", "Josip", 1 },
                    { 2, "Ruđera Boškovića 29", "Vasiljević", "Ive", 2 },
                    { 3, "Debeljak bb", "Torbarina", "Ivan", 2 },
                    { 4, "Miroslava Kraljevića 20", "Krpan", "Marko", 2 },
                    { 5, "Osječka 18", "Jakešević", "Nela", 3 },
                    { 6, "S.S Kranjčevića 12", "Butorac", "Petar", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 1,
                columns: new[] { "ContactID", "UserID" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 2,
                columns: new[] { "ContactID", "UserID" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 3,
                columns: new[] { "ContactID", "UserID" },
                values: new object[] { 3, null });

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 4,
                columns: new[] { "ContactID", "UserID" },
                values: new object[] { 4, null });

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 5,
                columns: new[] { "ContactID", "UserID" },
                values: new object[] { 5, null });

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 6,
                columns: new[] { "ContactID", "UserID" },
                values: new object[] { 6, null });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_TagID",
                table: "Contact",
                column: "TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mail_Contact_ContactID",
                table: "Mail",
                column: "ContactID",
                principalTable: "Contact",
                principalColumn: "ContactID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Number_Contact_UserID",
                table: "Number",
                column: "UserID",
                principalTable: "Contact",
                principalColumn: "ContactID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mail_Contact_ContactID",
                table: "Mail");

            migrationBuilder.DropForeignKey(
                name: "FK_Number_Contact_UserID",
                table: "Number");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Number");

            migrationBuilder.RenameColumn(
                name: "ContactID",
                table: "Mail",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Mail_ContactID",
                table: "Mail",
                newName: "IX_Mail_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Number",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Tag_TagID",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Address", "LastName", "Name", "TagID" },
                values: new object[,]
                {
                    { 1, "Crikvenička 2/1", "Zelić", "Josip", 1 },
                    { 2, "Ruđera Boškovića 29", "Vasiljević", "Ive", 2 },
                    { 3, "Debeljak bb", "Torbarina", "Ivan", 2 },
                    { 4, "Miroslava Kraljevića 20", "Krpan", "Marko", 2 },
                    { 5, "Osječka 18", "Jakešević", "Nela", 3 },
                    { 6, "S.S Kranjčevića 12", "Butorac", "Petar", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 1,
                column: "UserID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 2,
                column: "UserID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 3,
                column: "UserID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 4,
                column: "UserID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 5,
                column: "UserID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Number",
                keyColumn: "NumberID",
                keyValue: 6,
                column: "UserID",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "IX_User_TagID",
                table: "User",
                column: "TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mail_User_UserID",
                table: "Mail",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Number_User_UserID",
                table: "Number",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
