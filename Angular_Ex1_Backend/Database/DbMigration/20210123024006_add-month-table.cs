using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular_Ex1_Backend.Database.DbMigration
{
    public partial class addmonthtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthYear",
                table: "ReservationCoverages");

            migrationBuilder.AddColumn<long>(
                name: "MonthsMonthId",
                table: "ServicesBill",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MonthsMonthId",
                table: "ReservationCoverages",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    MonthId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.MonthId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesBill_MonthsMonthId",
                table: "ServicesBill",
                column: "MonthsMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCoverages_MonthsMonthId",
                table: "ReservationCoverages",
                column: "MonthsMonthId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationCoverages_Months_MonthsMonthId",
                table: "ReservationCoverages",
                column: "MonthsMonthId",
                principalTable: "Months",
                principalColumn: "MonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesBill_Months_MonthsMonthId",
                table: "ServicesBill",
                column: "MonthsMonthId",
                principalTable: "Months",
                principalColumn: "MonthId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationCoverages_Months_MonthsMonthId",
                table: "ReservationCoverages");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesBill_Months_MonthsMonthId",
                table: "ServicesBill");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropIndex(
                name: "IX_ServicesBill_MonthsMonthId",
                table: "ServicesBill");

            migrationBuilder.DropIndex(
                name: "IX_ReservationCoverages_MonthsMonthId",
                table: "ReservationCoverages");

            migrationBuilder.DropColumn(
                name: "MonthsMonthId",
                table: "ServicesBill");

            migrationBuilder.DropColumn(
                name: "MonthsMonthId",
                table: "ReservationCoverages");

            migrationBuilder.AddColumn<DateTime>(
                name: "MonthYear",
                table: "ReservationCoverages",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
