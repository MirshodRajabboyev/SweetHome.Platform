using System.Runtime.CompilerServices;

namespace SweetHome.Domain.Exceptions.Users;

public class UserNotFountException : NotFountException
{
    public UserNotFountException()
    {
        this.TitleMessage = "Пользователь не найден";
    }
}
