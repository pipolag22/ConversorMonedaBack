using System.ComponentModel.DataAnnotations;

namespace ConversionDeMonedas.Models.Dtos
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Contrasenia { get; set; }
    }
}
