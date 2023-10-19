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
}