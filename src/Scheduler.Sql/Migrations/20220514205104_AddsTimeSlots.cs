using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduler.Infra.Sql.Migrations
{
    public partial class AddsTimeSlots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LectureGroups_Season_SeasonId",
                table: "LectureGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorPreference_Professors_ProfessorId",
                table: "ProfessorPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Season",
                table: "Season");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorPreference",
                table: "ProfessorPreference");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "LectureGroups");

            migrationBuilder.DropColumn(
                name: "MinutesPerLecture",
                table: "LectureGroups");

            migrationBuilder.RenameTable(
                name: "Season",
                newName: "Seasons");

            migrationBuilder.RenameTable(
                name: "ProfessorPreference",
                newName: "ProfessorPreferences");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorPreference_ProfessorId",
                table: "ProfessorPreferences",
                newName: "IX_ProfessorPreferences_ProfessorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorPreferences",
                table: "ProfessorPreferences",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SeasonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsBreak = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    LectureGroupId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_LectureGroups_LectureGroupId",
                        column: x => x.LectureGroupId,
                        principalTable: "LectureGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TimeSlots_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_LectureGroupId",
                table: "TimeSlots",
                column: "LectureGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_SeasonId",
                table: "TimeSlots",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_LectureGroups_Seasons_SeasonId",
                table: "LectureGroups",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorPreferences_Professors_ProfessorId",
                table: "ProfessorPreferences",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LectureGroups_Seasons_SeasonId",
                table: "LectureGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorPreferences_Professors_ProfessorId",
                table: "ProfessorPreferences");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorPreferences",
                table: "ProfessorPreferences");

            migrationBuilder.RenameTable(
                name: "Seasons",
                newName: "Season");

            migrationBuilder.RenameTable(
                name: "ProfessorPreferences",
                newName: "ProfessorPreference");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorPreferences_ProfessorId",
                table: "ProfessorPreference",
                newName: "IX_ProfessorPreference_ProfessorId");

            migrationBuilder.AddColumn<double>(
                name: "Credits",
                table: "LectureGroups",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MinutesPerLecture",
                table: "LectureGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Season",
                table: "Season",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorPreference",
                table: "ProfessorPreference",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LectureGroups_Season_SeasonId",
                table: "LectureGroups",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorPreference_Professors_ProfessorId",
                table: "ProfessorPreference",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
