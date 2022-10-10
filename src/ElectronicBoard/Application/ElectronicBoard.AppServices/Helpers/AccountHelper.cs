using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ElectronicBoard.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ElectronicBoard.AppServices.Helpers;

public static class AccountHelper
{
    private const string AuthOption = "AuthOption";
    private const string Issuer = "Issuer";
    private const string Audience = "Audience";
    private const string SecretKey = "SecretKey";

    private const string ConfirmCodeTemplate = "FB-";

    public static string HashPassword(string password)
    {
        using(var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hash = BitConverter.ToString(hashedBytes).Replace("-","").ToLower();  
            return hash;
        }
    }

    public static string CreateJwtToken(this AccountEntity account, IConfiguration configuration)
    {
        var authOptions = configuration.GetSection(AuthOption);
        
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, account.Id.ToString()),
            new(ClaimTypes.Name, account.Login)
        };
        
        var jwt = new JwtSecurityToken(
            issuer: authOptions.GetSection(Issuer).Value,
            audience: authOptions.GetSection(Audience).Value,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(365)), // время действия 2 минуты
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.GetSection(SecretKey).Value)), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public static string GetConfirmCode()
    {
        return ConfirmCodeTemplate + Random.Shared.Next(0, 9999).ToString("D4");
    }
}