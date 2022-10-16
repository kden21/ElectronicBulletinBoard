using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ElectronicBoard.Registrar.Registrars;

public static class AuthRegistrar
{
    /// <summary>
    /// Строка с настройками для авторизации
    /// </summary>
    private const string AuthOption = "AuthOption";
    
    /// <summary>
    /// Издатель токена
    /// </summary>
    private const string Issuer = "Issuer";
    
    /// <summary>
    /// Потребитель токена
    /// </summary>
    private const string Audience = "Audience";
    
    /// <summary>
    /// Ключ для шифрования
    /// </summary>
    private const string SecretKey = "SecretKey";

    public static void AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        var authOptions = configuration.GetSection(AuthOption);
        
        if (authOptions == null)
            throw new InvalidOperationException(
                $"Не найдена строка с настройками авторизации: '{AuthOption}'");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,
                    // строка, представляющая издателя
                    ValidIssuer = authOptions.GetSection(Issuer).Value,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience =  authOptions.GetSection(Audience).Value,
                    // будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.GetSection(SecretKey).Value)),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true
                };
            })
            
            //TODO: Авторизация через ВК
            /*.AddOAuth("VK", "VKontakte", config =>
            {
                config.ClientId = configuration["Authentication:VK:AppId"];
                config.ClientSecret = configuration["Authentication:VK:AppSecret"];
                config.ClaimsIssuer = "VKontakte";
                config.CallbackPath = new PathString("/signin-vkontakte-token");
                config.AuthorizationEndpoint = "https://oauth.vk.com/authorize";
                config.TokenEndpoint = "https://oauth.vk.com/access_token";
                config.Scope.Add("email");
                config.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "user_id");
                config.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                config.SaveTokens = true;
                config.Events = new OAuthEvents
                {
                    OnCreatingTicket = context =>
                    {
                        context.RunClaimActions(context.TokenResponse.Response.RootElement);
                        return Task.CompletedTask;
                    },
                    OnRemoteFailure = OnFailure
                };
            })*/;
    }

    /*private static Task OnFailure(RemoteFailureContext arg)
    {
        return Task.CompletedTask;
    }*/
}