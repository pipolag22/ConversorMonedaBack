using System.ComponentModel.DataAnnotations;

namespace ConversionDeMonedas.Models.Dtos
{
    public class CreateAndUpdateCoinDto
    {
        public string Leyenda { get; set; }
        public string Simbolo { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El índice de conversión debe ser un número mayor a 0.")]
        public double IC { get; set; }
    }
}
