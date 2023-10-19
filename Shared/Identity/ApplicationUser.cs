namespace ElectronicJurnal.Shared.Identity;

#nullable disable
public class ApplicationUser
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    //you may add more properties here
}