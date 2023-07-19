using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginApplication.Migrations
{
    public partial class AddDBTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SignUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    NewPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AccountCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountEdited = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignUps");
        }
    }
}
