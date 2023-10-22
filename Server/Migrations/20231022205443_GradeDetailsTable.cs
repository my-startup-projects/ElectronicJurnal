using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicJournal.Server.Migrations
{
    /// <inheritdoc />
    public partial class GradeDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Users_StudentID",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GradeValue",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "isAbsent",
                table: "Grades");

            migrationBuilder.CreateTable(
                name: "GradeDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GradeValue = table.Column<int>(type: "int", nullable: false),
                    isAbsent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GradeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeDetails_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeDetails_Users_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GradeDetails_GradeId",
                table: "GradeDetails",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeDetails_StudentID",
                table: "GradeDetails",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradeDetails");

            migrationBuilder.AddColumn<int>(
                name: "GradeValue",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentID",
                table: "Grades",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<bool>(
                name: "isAbsent",
                table: "Grades",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentID",
                table: "Grades",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Users_StudentID",
                table: "Grades",
                column: "StudentID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
