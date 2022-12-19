using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ElectronicBoard.Contracts.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace ElectronicBoard.AppServices.Shared.Helpers.AuthorizationHelper;

public static class AuthorizationHelper
{
    /// <summary>
    /// Возвращает идентификатор пользователя из токена.
    /// </summary>
    /// <returns></returns>
    public static int? GetUserId(HttpRequest Request)
    {
        var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
        if(_bearer_token!="")
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(_bearer_token) as JwtSecurityToken;
            var id = tokenS.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            
            return Int32.Parse(id);
        }

        return null;
    }
    
    public static Role? GetUserRole(HttpRequest Request)
    {
        var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
        if(_bearer_token!="")
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(_bearer_token) as JwtSecurityToken;
            var role = tokenS.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;

            if (role == "Admin")
                return Role.Admin;
            else if (role == "User")
                return Role.User;
            else
            {
                return null;
            }
        }
        return null;
    }
}