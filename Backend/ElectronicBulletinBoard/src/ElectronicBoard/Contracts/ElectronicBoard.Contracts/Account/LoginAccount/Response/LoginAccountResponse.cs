namespace ElectronicBoard.Contracts.Account.LoginAccount.Response;

public class LoginAccountResponse
{
    /// <summary>
    /// Токен авторизации.
    /// </summary>
    public string JWTToken { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int UserId { get; set; }
}