using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConversionDeMonedas.Entities
{
    public class MonedasDefault
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Leyenda { get; set; }

        [Required]
        public string Simbolo { get; set; }

        [Required]
        public double IC { get; set; }
    }
}
