using System.ComponentModel.DataAnnotations;

namespace Aplikacja_1.Models
{
    public class Uzytkownik
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Imie { get; set; }
        [Required]
        [StringLength(60)]
        public string Nazwisko { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    
        [Required]
        [StringLength(300)]
        public string Adres {  get; set; }



        public virtual ICollection<Zamowienie> Zamowienia { get; set; } = new List<Zamowienie>();

    }
}
