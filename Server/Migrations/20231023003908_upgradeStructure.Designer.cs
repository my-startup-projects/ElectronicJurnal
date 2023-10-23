﻿// <auto-generated />
using System;
using ElectronicJournal.Server.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectronicJournal.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231023003908_upgradeStructure")]
    partial class upgradeStructure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GradeValue")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SubjectID")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StudentID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ScheduleID")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.GradeDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("GradeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("GradeValue")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("char(36)");

                    b.Property<bool>("isAbsent")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("StudentID");

                    b.ToTable("GradeDetails");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Journal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("SchoolClassID")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("SchoolClassID");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<Guid>("JournalID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SubjectID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TeacherID")
                        .HasColumnType("char(36)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JournalID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.SchoolClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Course")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SchoolClasses");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Identity.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("DateOfBirthday")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Student", b =>
                {
                    b.HasBaseType("ElectronicJournal.Shared.Identity.ApplicationUser");

                    b.Property<Guid>("SchoolClassID")
                        .HasColumnType("char(36)");

                    b.HasIndex("SchoolClassID");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Teacher", b =>
                {
                    b.HasBaseType("ElectronicJournal.Shared.Identity.ApplicationUser");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Exam", b =>
                {
                    b.HasOne("ElectronicJournal.Shared.Entity.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Shared.Entity.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Grade", b =>
                {
                    b.HasOne("ElectronicJournal.Shared.Entity.Schedule", "Schedule")
                        .WithMany("Grades")
                        .HasForeignKey("ScheduleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.GradeDetail", b =>
                {
                    b.HasOne("ElectronicJournal.Shared.Entity.Grade", "Grade")
                        .WithMany("GradeDetails")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Shared.Entity.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Journal", b =>
                {
                    b.HasOne("ElectronicJournal.Shared.Entity.SchoolClass", "SchoolClass")
                        .WithMany("Journals")
                        .HasForeignKey("SchoolClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolClass");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Schedule", b =>
                {
                    b.HasOne("ElectronicJournal.Shared.Entity.Journal", "Journal")
                        .WithMany("Schedules")
                        .HasForeignKey("JournalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Shared.Entity.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Shared.Entity.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journal");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Student", b =>
                {
                    b.HasOne("ElectronicJournal.Shared.Entity.SchoolClass", "SchoolClass")
                        .WithMany("Students")
                        .HasForeignKey("SchoolClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolClass");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Grade", b =>
                {
                    b.Navigation("GradeDetails");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Journal", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.Schedule", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("ElectronicJournal.Shared.Entity.SchoolClass", b =>
                {
                    b.Navigation("Journals");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
