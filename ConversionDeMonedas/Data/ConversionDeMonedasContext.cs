using ConversionDeMonedas.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConversionDeMonedas.Data
{
    public class ConversionDeMonedasContext : DbContext
    {
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<MonedasUser> monedasUser { get; set; }
        public DbSet<MonedasDefault> monedasDefault { get; set; }
        public DbSet<Favoritas> Favoritas { get; set; }

        public ConversionDeMonedasContext(DbContextOptions<ConversionDeMonedasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MonedasDefault pesoArgentino = new MonedasDefault()
            {
                Id = 1,
                Leyenda = "Peso Argentino",
                Simbolo = "Ars$",
                IC = 0.002
            };
            MonedasDefault dolarAmericano = new MonedasDefault()
            {
                Id = 2,
                Leyenda = "Dolar Americano",
                Simbolo = "Usd$",
                IC = 1
            };
            MonedasDefault coronaCheca = new MonedasDefault()
            {
                Id = 3,
                Leyenda = "CoroaCheca",
                Simbolo = "KC",
                IC = 0.043
            };
            MonedasDefault euro = new MonedasDefault()
            {
                Id = 4,
                Leyenda = "Euro",
                Simbolo = "Eur$",
                IC = 1.09
            };
            MonedasDefault bitcoin = new MonedasDefault()
            {
                Id = 5,
                Leyenda = "Bictoin",
                Simbolo = "Btc",
                IC = 0.000012
            };

            modelBuilder.Entity<MonedasDefault>().HasData(
               pesoArgentino, dolarAmericano, coronaCheca, euro, bitcoin);

            base.OnModelCreating(modelBuilder);
        }
    }
}
