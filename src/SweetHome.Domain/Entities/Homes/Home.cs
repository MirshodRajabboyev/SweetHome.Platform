using System.ComponentModel.DataAnnotations;

namespace SweetHome.Domain.Entities.Homes;

public class Home : Auditable
{
    [MaxLength(50)]
    public string Manzil { get; set; } = String.Empty;

    public int Xonalar_soni { get; set; }

    public int Etaj { get; set; }

    public int Etaj_zdaniya { get; set; }

    [MaxLength(30)]
    public string Remont { get; set; } = String.Empty;

    [MaxLength(30)]
    public string Narx { get; set; } = String.Empty;

    [MaxLength(30)]
    public string Narx_variant { get; set; } = String.Empty;

    public string Tavsif { get; set; } = String.Empty;

    public string Rasm_1 { get; set; } = String.Empty;

    public string Rasm_2 { get; set; } = String.Empty;

    public string Rasm_3 { get; set; } = String.Empty;

    public string Rasm_4 { get; set; } = String.Empty;

    public string Rasm_5 { get; set; } = String.Empty;

    public string Rasm_6 { get; set; } = String.Empty;

    public string Rasm_7 { get; set; } = String.Empty;

    public string Rasm_8 { get; set; } = String.Empty;

    public long UserId { get; set; } 

}
