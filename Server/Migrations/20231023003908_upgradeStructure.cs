using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicJournal.Server.Migrations
{
    /// <inheritdoc />
    public partial class upgradeStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Journals_JournalID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_SchoolClasses_SchoolClassID",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "SchoolClassID",
                table: "Schedules",
                newName: "JournalID");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_SchoolClassID",
                table: "Schedules",
                newName: "IX_Schedules_JournalID");

            migrationBuilder.RenameColumn(
                name: "JournalID",
                table: "Grades",
                newName: "ScheduleID");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_JournalID",
                table: "Grades",
                newName: "IX_Grades_ScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Schedules_ScheduleID",
                table: "Grades",
                column: "ScheduleID",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Journals_JournalID",
                table: "Schedules",
                column: "JournalID",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Schedules_ScheduleID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Journals_JournalID",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "JournalID",
                table: "Schedules",
                newName: "SchoolClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_JournalID",
                table: "Schedules",
                newName: "IX_Schedules_SchoolClassID");

            migrationBuilder.RenameColumn(
                name: "ScheduleID",
                table: "Grades",
                newName: "JournalID");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_ScheduleID",
                table: "Grades",
                newName: "IX_Grades_JournalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Journals_JournalID",
                table: "Grades",
                column: "JournalID",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_SchoolClasses_SchoolClassID",
                table: "Schedules",
                column: "SchoolClassID",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
