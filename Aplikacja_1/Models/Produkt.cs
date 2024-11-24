using System.ComponentModel.DataAnnotations;

namespace Aplikacja_1.Models
{
    public class Produkt
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nazwa { get; set; }
        public string? Opis { get; set; }
        [Required]
        public decimal Waga { get; set; }
        [Required]
        public decimal Cena { get; set; }

        public string? Składniki { get; set; }
        public string Kategoria { get; set; }

        public string Zdjecie { get; set; }

        public virtual ICollection<Zamowienie> Zamowienia { get; set; } = new List<Zamowienie>();

    }
}
