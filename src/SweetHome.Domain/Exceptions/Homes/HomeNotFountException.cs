namespace SweetHome.Domain.Exceptions.Homes;

public class HomeNotFountException : NotFountException
{
    public HomeNotFountException()
    {
        this.TitleMessage = "Пользователь не найден";
    }
}
