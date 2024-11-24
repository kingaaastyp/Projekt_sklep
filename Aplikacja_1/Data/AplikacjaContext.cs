using Aplikacja_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplikacja_1.Data
{
    public class AplikacjaContext :DbContext
    {
        public AplikacjaContext(DbContextOptions<AplikacjaContext> options): base(options) { }

        public DbSet<Produkt> Produkty {  get; set; }
        public DbSet <Uzytkownik> Uzytkownicy { get; set;}
        public DbSet<Zamowienie> Zamowienia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Zamowienie>()
                .HasMany(z => z.Produkty)
                .WithMany(p => p.Zamowienia)
                .UsingEntity(j => j.ToTable("ZamowieniaProdukty"));
        }

    }




}
