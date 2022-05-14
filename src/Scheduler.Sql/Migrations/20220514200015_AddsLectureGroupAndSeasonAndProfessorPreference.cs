using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduler.Infra.Sql.Migrations
{
    public partial class AddsLectureGroupAndSeasonAndProfessorPreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxLectureGroups",
                table: "Professors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isAdjunct",
                table: "Professors",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProfessorPreference",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PreferredDay = table.Column<int>(type: "int", nullable: true),
                    PreferredTime = table.Column<TimeOnly>(type: "time(6)", nullable: true),
                    NotPreferredDay = table.Column<int>(type: "int", nullable: true),
                    NotPreferredTime = table.Column<TimeOnly>(type: "time(6)", nullable: true),
                    ProfessorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorPreference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorPreference_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(127)", maxLength: 127, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LectureGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CourseCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourseName = table.Column<string>(type: "varchar(127)", maxLength: 127, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Credits = table.Column<double>(type: "double", nullable: false),
                    LectureDaysPerWeek = table.Column<int>(type: "int", nullable: false),
                    MinutesPerLecture = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SeasonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LectureGroups_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LectureGroups_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LectureGroups_ProfessorId",
                table: "LectureGroups",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureGroups_SeasonId",
                table: "LectureGroups",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorPreference_ProfessorId",
                table: "ProfessorPreference",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureGroups");

            migrationBuilder.DropTable(
                name: "ProfessorPreference");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropColumn(
                name: "MaxLectureGroups",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "isAdjunct",
                table: "Professors");
        }
    }
}
