using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicJournal.Server.Migrations
{
    /// <inheritdoc />
    public partial class IDChangedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Subjects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SchoolClasses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Schedules",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Journals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Grades",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Exams",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subjects",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SchoolClasses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Schedules",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Journals",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Grades",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Exams",
                newName: "ID");
        }
    }
}
