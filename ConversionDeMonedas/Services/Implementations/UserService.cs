using ConversionDeMonedas.Data;
using ConversionDeMonedas.Entities;
using ConversionDeMonedas.Models.Dtos;
using ConversionDeMonedas.Models.Enum;

namespace ConversionDeMonedas.Services.Implementations
{
    public class UserService
    {
        private readonly ConversionDeMonedasContext _CDMContext;
        public UserService(ConversionDeMonedasContext context)
        {
            _CDMContext = context;
        }
        public Usuario? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _CDMContext.usuario.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Contrasenia == authRequestBody.Contrasenia);
        }

        public void Create(CreateUserDto dto)
        { 
            Usuario newUser = new Usuario()
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                Contrasenia = dto.Contrasenia,
                Suscripcion = Suscripcion.Free, 
                TotalConversiones = 10
            };
            _CDMContext.usuario.Add(newUser);
            _CDMContext.SaveChanges();
        }
    }
}
