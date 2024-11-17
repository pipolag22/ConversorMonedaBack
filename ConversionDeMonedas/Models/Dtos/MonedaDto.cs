using System.ComponentModel.DataAnnotations;

namespace ConversionDeMonedas.Models.Dtos
{
    public class MonedaDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Leyenda { get; set; }

        [Required]
        public string Simbolo { get; set; }

        [Required]
        public double IC { get; set; }
    }
}
