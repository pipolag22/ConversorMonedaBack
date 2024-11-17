using ConversionDeMonedas.Models.Enum;

namespace ConversionDeMonedas.Models.Dtos
{
    public class CreateUserDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
    }
}
