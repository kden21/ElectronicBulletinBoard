using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Net.Http.Headers;

namespace ElectronicBoard.AppServices.Shared.Helpers.AuthorizationHelper;

public static class AuthorizationHelper
{
    /// <summary>
    /// Возвращает идентификатор пользователя из токена.
    /// </summary>
    /// <returns></returns>
    /*public static int GetUserId()
    {
        //TODO:проверка на пользователя
        var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
        if(_bearer_token!="")
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(_bearer_token) as JwtSecurityToken;
            var id = tokenS.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
        }
    }*/
}