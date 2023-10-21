using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Shared.Identity;

#nullable disable
public class ApplicationUser : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }   
    public string FullName { get; set; }

    public DateOnly DateOfBirthday { get; set; }    
}