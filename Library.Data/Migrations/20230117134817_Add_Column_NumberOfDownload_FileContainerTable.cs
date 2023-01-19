using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class Add_Column_NumberOfDownload_FileContainerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfUploaded",
                table: "FileContainers",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 17, 13, 48, 17, 344, DateTimeKind.Utc).AddTicks(6455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 15, 17, 42, 28, 890, DateTimeKind.Utc).AddTicks(4181));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDownload",
                table: "FileContainers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDownload",
                table: "FileContainers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfUploaded",
                table: "FileContainers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 15, 17, 42, 28, 890, DateTimeKind.Utc).AddTicks(4181),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 1, 17, 13, 48, 17, 344, DateTimeKind.Utc).AddTicks(6455));
        }
    }
}
