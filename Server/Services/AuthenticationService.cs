using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ElectronicJurnal.Server.DataBase;
using ElectronicJurnal.Shared.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ElectronicJurnal.Server.Services;

public class AuthenticationService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IConfiguration _configurations;

    public AuthenticationService(ApplicationDbContext applicationDbContext, IConfiguration configurations)
    {
        _applicationDbContext = applicationDbContext;
        _configurations = configurations;
    }

    public async Task<bool> Register(ApplicationUser user)
    {
        try
        {
            await _applicationDbContext.Users.AddAsync(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<string?> Login(string username, string password)
    {
        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u =>
            u.Username == username && u.Password == password);
        if (user == null)
        {
            return null;
        }

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(ApplicationUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurations["JWT:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}