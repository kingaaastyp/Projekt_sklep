using Aplikacja_1.Data;
using Aplikacja_1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dodanie kontekstu bazy danych
builder.Services.AddDbContext<AplikacjaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AplikacjaSklepuDB")));

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AplikacjaContext>();

    // Pobierz istniej¹cego u¿ytkownika
    var uzytkownik = context.Uzytkownicy.FirstOrDefault();
    if (uzytkownik != null)
    {
        // Dodaj nowe zamówienie
        var zamowienie = new Zamowienie
        {
            Data = DateTime.Now,
            UzytkownikId = uzytkownik.Id
        };
        context.Zamowienia.Add(zamowienie);
        context.SaveChanges();
        Console.WriteLine("Dodano zamówienie dla u¿ytkownika: " + uzytkownik.Imie);
    }
    else
    {
        Console.WriteLine("Brak u¿ytkowników w tabeli Uzytkownicy.");
    }
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
