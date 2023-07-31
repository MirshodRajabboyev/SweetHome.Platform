using SweetHome.Domain.Enums;

namespace SweetHome.Service.Dtos.Users;

public class UserUpdateDto
{
    public string Ism { get; set; } = String.Empty;

    public string Familiya { get; set; } = String.Empty;

    public string TelNomer { get; set; } = String.Empty;

    public string Parol { get; set; } = String.Empty;

}
