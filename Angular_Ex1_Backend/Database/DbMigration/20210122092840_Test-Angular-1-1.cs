using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular_Ex1_Backend.Database.DbMigration
{
    public partial class TestAngular11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ServicesBill",
                newName: "MonthYear");

            migrationBuilder.AlterColumn<float>(
                name: "TotalHours",
                table: "ReservationCoverages",
                type: "float",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned");

            migrationBuilder.AlterColumn<float>(
                name: "ReservedHours",
                table: "ReservationCoverages",
                type: "float",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonthYear",
                table: "ServicesBill",
                newName: "Date");

            migrationBuilder.AlterColumn<uint>(
                name: "TotalHours",
                table: "ReservationCoverages",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<uint>(
                name: "ReservedHours",
                table: "ReservationCoverages",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");
        }
    }
}
