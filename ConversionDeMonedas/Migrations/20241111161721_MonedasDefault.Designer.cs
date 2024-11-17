﻿// <auto-generated />
using ConversionDeMonedas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConversionDeMonedas.Migrations
{
    [DbContext(typeof(ConversionDeMonedasContext))]
    [Migration("20241111161721_MonedasDefault")]
    partial class MonedasDefault
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("ConversionDeMonedas.Entities.Favoritas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("IC")
                        .HasColumnType("REAL");

                    b.Property<string>("Leyenda")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Simbolo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Favoritas");
                });

            modelBuilder.Entity("ConversionDeMonedas.Entities.MonedasDefault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("IC")
                        .HasColumnType("REAL");

                    b.Property<string>("Leyenda")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Simbolo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("monedasDefault");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IC = 0.002,
                            Leyenda = "Peso Argentino",
                            Simbolo = "Ars$"
                        },
                        new
                        {
                            Id = 2,
                            IC = 1.0,
                            Leyenda = "Dolar Americano",
                            Simbolo = "Usd$"
                        },
                        new
                        {
                            Id = 3,
                            IC = 0.042999999999999997,
                            Leyenda = "CoroaCheca",
                            Simbolo = "KC"
                        },
                        new
                        {
                            Id = 4,
                            IC = 1.0900000000000001,
                            Leyenda = "Euro",
                            Simbolo = "Eur$"
                        },
                        new
                        {
                            Id = 5,
                            IC = 1.2E-05,
                            Leyenda = "Bictoin",
                            Simbolo = "Btc"
                        });
                });

            modelBuilder.Entity("ConversionDeMonedas.Entities.MonedasUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("IC")
                        .HasColumnType("REAL");

                    b.Property<string>("Leyenda")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Simbolo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("monedasUser");
                });

            modelBuilder.Entity("ConversionDeMonedas.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Suscripcion")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalConversiones")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("ConversionDeMonedas.Entities.Favoritas", b =>
                {
                    b.HasOne("ConversionDeMonedas.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ConversionDeMonedas.Entities.MonedasUser", b =>
                {
                    b.HasOne("ConversionDeMonedas.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}