using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.Account.RegisterAccount;

public class RegisterRequest
{
    /*login: string,
    password: string,
    name: string,
    middleName?: string,
    lastName: string,
    birthday: string,
    phoneNumber: string,
    role: StatusRole,
    photo: "",
    email: string,
    accountId?: number,
    token?: string,
    statusUser:StatusUser*/
    public string Login { get; set; }
    public string Password{ get; set; }
    public string Name { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string? Birthday { get; set; }
    public Role Role { get; set; }
    //public string? Photo { get; set; }
    public string? Email { get; set; }
    public int AccountId { get; set; }
    public StatusUser StatusUser { get; set; }
    public string? PhoneNumber { get; set; }
}