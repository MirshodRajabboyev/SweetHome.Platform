using SweetHome.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SweetHome.Domain.Entities.Users;

public class User : Auditable
{
    [MaxLength(50)]
    public string Ism { get; set; } = String.Empty;

    [MaxLength(50)]
    public string Familiya { get; set; } = String.Empty;
    
    [MaxLength(15)]
    public string TelNomer { get; set; } = String.Empty;

    public bool TelNomerConfirmed { get; set; }


    [MaxLength(30)]
    public string Parol { get; set; } = String.Empty;

    public IDentityRole IdentityRole { get; set; }
}
