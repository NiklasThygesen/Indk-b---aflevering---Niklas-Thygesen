using System.ComponentModel.DataAnnotations;

namespace Indkøb.Models
{
    public class TilføjVarer
    {
        [Required(ErrorMessage = "Venligst indtast varer")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Venligst indtast antal stk.")]
        public int? Amount { get; set; }

        [Required(ErrorMessage = "Vælg venligst en kategori")]
        public string? Category { get; set; } // Ny egenskab til kategori
    }
}
