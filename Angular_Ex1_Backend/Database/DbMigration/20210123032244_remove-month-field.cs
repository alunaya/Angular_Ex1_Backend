using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular_Ex1_Backend.Database.DbMigration
{
    public partial class removemonthfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthYear",
                table: "ServicesBill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MonthYear",
                table: "ServicesBill",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
