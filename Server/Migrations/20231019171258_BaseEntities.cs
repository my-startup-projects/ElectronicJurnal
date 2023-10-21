using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicJournal.Server.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirthday",
                table: "Users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolClassID",
                table: "Users",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "SchoolClasses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClasses", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SchoolClassID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AcademicYear = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Journals_SchoolClasses_SchoolClassID",
                        column: x => x.SchoolClassID,
                        principalTable: "SchoolClasses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubjectID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GradeValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exams_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exams_Users_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SchoolClassID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubjectID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeacherID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Schedules_SchoolClasses_SchoolClassID",
                        column: x => x.SchoolClassID,
                        principalTable: "SchoolClasses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Users_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    JournalID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GradeValue = table.Column<int>(type: "int", nullable: false),
                    isAbsent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grades_Journals_JournalID",
                        column: x => x.JournalID,
                        principalTable: "Journals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Users_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolClassID",
                table: "Users",
                column: "SchoolClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StudentID",
                table: "Exams",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SubjectID",
                table: "Exams",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_JournalID",
                table: "Grades",
                column: "JournalID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentID",
                table: "Grades",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_SchoolClassID",
                table: "Journals",
                column: "SchoolClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SchoolClassID",
                table: "Schedules",
                column: "SchoolClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SubjectID",
                table: "Schedules",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeacherID",
                table: "Schedules",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SchoolClasses_SchoolClassID",
                table: "Users",
                column: "SchoolClassID",
                principalTable: "SchoolClasses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SchoolClasses_SchoolClassID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "SchoolClasses");

            migrationBuilder.DropIndex(
                name: "IX_Users_SchoolClassID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirthday",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SchoolClassID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");
        }
    }
}
