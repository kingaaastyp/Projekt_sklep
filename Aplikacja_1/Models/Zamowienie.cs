using System.ComponentModel.DataAnnotations;
namespace Aplikacja_1.Models
{
    public class Zamowienie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int UzytkownikId {  get; set; }
        [Required]
        public virtual Uzytkownik Uzytkownik { get; set; }
        public virtual ICollection<Produkt> Produkty { get; set; } = new List<Produkt>();


    }
}
