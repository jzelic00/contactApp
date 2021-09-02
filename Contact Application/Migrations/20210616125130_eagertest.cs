using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact_Application.Migrations
{
    public partial class eagertest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBookmarked = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Mail",
                columns: table => new
                {
                    MailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mail", x => x.MailID);
                    table.ForeignKey(
                        name: "FK_Mail_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Number",
                columns: table => new
                {
                    NumberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Number", x => x.NumberID);
                    table.ForeignKey(
                        name: "FK_Number_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "TagName" },
                values: new object[] { 1, "Obitelj" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "TagName" },
                values: new object[] { 2, "Prijatelj" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "TagName" },
                values: new object[] { 3, "Posao" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Address", "IsBookmarked", "LastName", "Name", "TagID" },
                values: new object[,]
                {
                    { 1, "Crikvenička 2/1", false, "Zelić", "Josip", 1 },
                    { 2, "Ruđera Boškovića 29", false, "Vasiljević", "Ive", 2 },
                    { 3, "Debeljak bb", false, "Torbarina", "Ivan", 2 },
                    { 4, "Miroslava Kraljevića 20", false, "Krpan", "Marko", 2 },
                    { 5, "Osječka 18", false, "Jakešević", "Nela", 3 },
                    { 6, "S.S Kranjčevića 12", false, "Butorac", "Petar", 3 }
                });

            migrationBuilder.InsertData(
                table: "Mail",
                columns: new[] { "MailID", "MailAddress", "UserID" },
                values: new object[,]
                {
                    { 1, "jzelic@gmail.com", 1 },
                    { 2, "zelic@fesb.hr", 1 },
                    { 3, "ivasil@gmail.com", 2 },
                    { 4, "itoroba@fgag.hr", 3 },
                    { 5, "krpica@hotmail.com", 4 },
                    { 6, "nelaj@outlook.com", 5 },
                    { 7, "pbutorac@outlook.com", 6 },
                    { 8, "pb1006@yahoo.com", 6 }
                });

            migrationBuilder.InsertData(
                table: "Number",
                columns: new[] { "NumberID", "PhoneNumber", "UserID" },
                values: new object[,]
                {
                    { 1, "0996993858", 1 },
                    { 2, "0991234562", 2 },
                    { 3, "0984568823", 3 },
                    { 4, "0912213486", 4 },
                    { 5, "0914459121", 5 },
                    { 6, "0981283221", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mail_UserID",
                table: "Mail",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Number_UserID",
                table: "Number",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_TagID",
                table: "User",
                column: "TagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mail");

            migrationBuilder.DropTable(
                name: "Number");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
