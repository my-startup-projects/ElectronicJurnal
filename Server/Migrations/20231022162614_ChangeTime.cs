using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicJournal.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Time",
                table: "Schedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Time",
                table: "Schedules",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
