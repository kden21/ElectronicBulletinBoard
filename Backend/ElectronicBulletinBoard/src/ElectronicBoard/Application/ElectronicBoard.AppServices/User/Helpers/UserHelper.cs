using ElectronicBoard.Contracts.Shared.Enums;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.User.Helpers;
//TODO:где используется этот класс?
/// <summary>
/// Хелпер для работы с пользователем.
/// </summary>
public static class UserHelper
{
    public static UserEntity DefaultUser(string userName, int accountId)
    {
        return new ()
        {
            Id = 0,
            AccountId = accountId,
            Name = (userName!=null) ? userName : "user",
            MiddleName = null,
            LastName = null,
            Birthday = null,
            PhoneNumber = null,
            Photo = null,
            Email = null,
            Role = Role.User
        };
    }
}