namespace SweetHome.Domain.Exceptions.Auth;

public class VerificationTooManyRequestsException : TooManyRequestException
{
    public VerificationTooManyRequestsException()
    {
        TitleMessage = "Вы пробовали больше, чем ограничения!";
    }
}
