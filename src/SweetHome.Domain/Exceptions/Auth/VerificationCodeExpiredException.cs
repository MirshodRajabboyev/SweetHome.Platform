namespace SweetHome.Domain.Exceptions.Auth;

public class VerificationCodeExpiredException : ExpiredException
{
    public VerificationCodeExpiredException()
    {
        TitleMessage = "Срок действия кода подтверждения истек!";
    }
}
