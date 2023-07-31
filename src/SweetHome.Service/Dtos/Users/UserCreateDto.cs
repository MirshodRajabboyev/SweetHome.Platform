using SweetHome.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SweetHome.Service.Dtos.Users;

public class UserCreateDto
{
    public string Ism { get; set; } = String.Empty;

    public string Familiya { get; set; } = String.Empty;

    public string TelNomer { get; set; } = String.Empty;

    public string Parol { get; set; } = String.Empty;

}
