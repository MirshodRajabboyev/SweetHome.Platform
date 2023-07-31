using System.Net;

namespace SweetHome.Domain.Exceptions;

public class NotFountException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = String.Empty;


}
