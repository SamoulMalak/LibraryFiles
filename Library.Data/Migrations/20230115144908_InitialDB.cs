using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileContainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true, defaultValue: "No description"),
                    FilePath = table.Column<string>(nullable: true),
                    FolderPath = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    DateOfUploaded = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2023, 1, 15, 14, 49, 8, 284, DateTimeKind.Utc).AddTicks(7213))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileContainers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileContainers");
        }
    }
}
