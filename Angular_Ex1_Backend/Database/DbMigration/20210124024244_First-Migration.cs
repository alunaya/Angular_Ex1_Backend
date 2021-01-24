using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular_Ex1_Backend.Database.DbMigration
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    MonthId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.MonthId);
                });

            migrationBuilder.CreateTable(
                name: "ReservationCoverages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InstanceType = table.Column<string>(type: "longtext", nullable: true),
                    ReservedHours = table.Column<float>(type: "float", nullable: false),
                    TotalHours = table.Column<float>(type: "float", nullable: false),
                    MonthsMonthId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationCoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationCoverages_Months_MonthsMonthId",
                        column: x => x.MonthsMonthId,
                        principalTable: "Months",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicesBill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServicesName = table.Column<string>(type: "longtext", nullable: true),
                    Bill = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MonthsMonthId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesBill_Months_MonthsMonthId",
                        column: x => x.MonthsMonthId,
                        principalTable: "Months",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCoverages_MonthsMonthId",
                table: "ReservationCoverages",
                column: "MonthsMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesBill_MonthsMonthId",
                table: "ServicesBill",
                column: "MonthsMonthId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationCoverages");

            migrationBuilder.DropTable(
                name: "ServicesBill");

            migrationBuilder.DropTable(
                name: "Months");
        }
    }
}
