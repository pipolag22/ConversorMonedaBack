using ConversionDeMonedas.Data;
using ConversionDeMonedas.Entities;
using ConversionDeMonedas.Helpers;
using ConversionDeMonedas.Models.Dtos;
using ConversionDeMonedas.Models.Enum;

namespace ConversionDeMonedas.Services.Implementations
{
    public class ViewService
    {
        private readonly ConversionDeMonedasContext _CDMContext;

        public ViewService(ConversionDeMonedasContext context)
        {
            _CDMContext = context;
        }

        public void UpdateSub(int userId, Suscripcion sub)
        {
            Usuario userToUpdate = _CDMContext.usuario.First(U => U.Id == userId);
            Totalconversiones total = new();

            userToUpdate.Suscripcion = sub;
            userToUpdate.TotalConversiones = total.GetTotalconversiones(sub);
            _CDMContext.SaveChanges();
        }

        public string GetSub(int userId)
        {
            Usuario user = _CDMContext.usuario.First(u => u.Id == userId);
            return user.Suscripcion.ToString();
        }

        public int GetTotalConvert(int userId)
        {
            Usuario user = _CDMContext.usuario.First(u => u.Id == userId);
            return user.TotalConversiones;
        }

        public List<MonedasUser> GetUsersCoins(int userId)
        {
            return _CDMContext.monedasUser.Where(u => u.UserId == userId).ToList();
        }

        public MonedaDto GetUserCoinById(int id)
        {
            MonedasUser monedaGet = _CDMContext.monedasUser.Single(u => u.Id == id);
            return new MonedaDto
            {
                Id = monedaGet.Id,
                Leyenda = monedaGet.Leyenda,
                Simbolo = monedaGet.Simbolo,
                IC = monedaGet.IC
            };
        }

        public List<MonedasDefault> GetDefaultCoins()
        {
            return _CDMContext.monedasDefault.ToList();
        }

        public List<Favoritas> GetFavsCoins(int userId)
        {
            return _CDMContext.Favoritas.Where(u => u.UserId == userId).ToList();
        }

        public Favoritas GetFavCoinByLeyenda(int userId, string leyenda)
        {
            return _CDMContext.Favoritas.SingleOrDefault(f => f.Leyenda == leyenda && f.UserId == userId);
        }
    }
}
