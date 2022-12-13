using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ElectronicBoard.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ElectronicBoard.AppServices.Account.Helpers;

/// <summary>
/// Хелпер для работы с аккаунтом.
/// </summary>
public static class AccountHelper
{
    private const string AuthOption = "AuthOption";
    private const string Issuer = "Issuer";
    private const string Audience = "Audience";
    private const string SecretKey = "SecretKey";

    /// <summary>
    /// Хеширование пароля.
    /// </summary>
    /// <param name="password">Пароль, введенный пользователем</param>
    /// <returns></returns>
    public static string HashPassword(this string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
    
    /// <summary>
    /// Создание JWT токена.
    /// </summary>
    /// <param name="account"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>

    public static string CreateJwtToken(this AccountEntity account, IConfiguration configuration)
    {
        var authOptions = configuration.GetSection(AuthOption);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new(ClaimTypes.Name, account.Login),
            new(ClaimTypes.Role, account.User?.Role.ToString() ?? "User")
        };

        var jwt = new JwtSecurityToken(
            issuer: authOptions.GetSection(Issuer).Value,
            audience: authOptions.GetSection(Audience).Value,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(365)),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.GetSection(SecretKey).Value)),
                SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}