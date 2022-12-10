namespace ElectronicBoard.Contracts.Account.LoginAccount.Response;

public class LoginAccountResponse
{
    public string JWTToken { get; set; }
    public int UserId { get; set; }
}