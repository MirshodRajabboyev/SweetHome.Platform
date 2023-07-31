using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SweetHome.Service.Dtos.Homes;

public class HomeCreateDto
{
    public string Manzil { get; set; } = String.Empty;

    public int Xonalar_soni { get; set; }

    public int Etaj { get; set; }

    public int Etaj_zdaniya { get; set; }

    public string Remont { get; set; } = String.Empty;

    public string Narx { get; set; } = String.Empty;

    public string Narx_variant { get; set; } = String.Empty;

    public string Tavsif { get; set; } = String.Empty;

    public IFormFile Rasm_1 { get; set; } = default!;

    public IFormFile Rasm_2 { get; set; } = default!;

    public IFormFile Rasm_3 { get; set; } = default!;

    public IFormFile Rasm_4 { get; set; } = default!;

    public IFormFile Rasm_5 { get; set; } = default!;

    public IFormFile Rasm_6 { get; set; } = default!;

    public IFormFile Rasm_7 { get; set; } = default!;

    public IFormFile Rasm_8 { get; set; } = default!;

}
