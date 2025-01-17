﻿// <auto-generated />
using System;
using Aplikacja_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aplikacja_1.Migrations
{
    [DbContext(typeof(AplikacjaContext))]
    [Migration("20241124185416_InitSchema")]
    partial class InitSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aplikacja_1.Models.Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Kategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Składniki")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Waga")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ZamowienieId")
                        .HasColumnType("int");

                    b.Property<string>("Zdjecie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ZamowienieId");

                    b.ToTable("Produkty");
                });

            modelBuilder.Entity("Aplikacja_1.Models.Uzytkownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Uzytkownicy");
                });

            modelBuilder.Entity("Aplikacja_1.Models.Zamowienie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("UzytkownikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UzytkownikId");

                    b.ToTable("Zamowienia");
                });

            modelBuilder.Entity("Aplikacja_1.Models.Produkt", b =>
                {
                    b.HasOne("Aplikacja_1.Models.Zamowienie", null)
                        .WithMany("Produkty")
                        .HasForeignKey("ZamowienieId");
                });

            modelBuilder.Entity("Aplikacja_1.Models.Zamowienie", b =>
                {
                    b.HasOne("Aplikacja_1.Models.Uzytkownik", "Uzytkownik")
                        .WithMany()
                        .HasForeignKey("UzytkownikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uzytkownik");
                });

            modelBuilder.Entity("Aplikacja_1.Models.Zamowienie", b =>
                {
                    b.Navigation("Produkty");
                });
#pragma warning restore 612, 618
        }
    }
}
