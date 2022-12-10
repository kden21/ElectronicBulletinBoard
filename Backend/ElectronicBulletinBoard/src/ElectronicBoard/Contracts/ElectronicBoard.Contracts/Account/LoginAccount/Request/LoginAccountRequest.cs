namespace ElectronicBoard.Contracts.Account.LoginAccount.Request;

public class LoginAccountRequest
{
    /// <summary>
    /// Логин пользователя.
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }
    
    
}