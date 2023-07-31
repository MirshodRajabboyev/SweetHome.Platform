namespace SweetHome.Domain.Exceptions.Users;

public class UserCacheDataExpiredException : ExpiredException
{
    public UserCacheDataExpiredException()
    {
        TitleMessage = "Срок действия пользовательских данных истек!";
    }
}
