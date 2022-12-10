using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.Account.RegisterAccount;

public class RegisterRequest
{
    public string Login { get; set; }
    public string Password{ get; set; }
    public string Name { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string? Birthday { get; set; }
    public Role Role { get; set; }
    public string? Email { get; set; }
    public int AccountId { get; set; }
    public StatusUser StatusUser { get; set; }
    public string? PhoneNumber { get; set; }
}