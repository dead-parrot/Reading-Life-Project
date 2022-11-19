using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingLifeProject.Migrations
{
    public partial class sprint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "books",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "Nota",
                table: "books",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "books",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "books");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "books");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "books");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "books");
        }
    }
}
