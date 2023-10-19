using ElectronicJurnal.Shared.Entity;
using ElectronicJurnal.Shared.Identity;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJurnal.Server.DataBase;

#nullable disable
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<SchoolClass> SchoolClasses { get; set;}
    public DbSet<Subject> Subjects { get; set; }

}