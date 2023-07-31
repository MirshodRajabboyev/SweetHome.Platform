namespace SweetHome.Domain.Exceptions.Users;

public class UserAlreadyExistsException : AlreadyExistsExcaption
{
    public UserAlreadyExistsException()
    {
        TitleMessage = "Пользователь уже существует";
    }

    public UserAlreadyExistsException(string phone)
    {
        TitleMessage = "\r\nЭтот телефон уже зарегистрирован";
    }
}
