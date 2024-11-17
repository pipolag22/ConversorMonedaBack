using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversionDeMonedas.Entities
{
    public class MonedasUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Leyenda { get; set; }

        [Required]
        public string Simbolo { get; set; }

        [Required]
        public double IC {  get; set; }

        [Required]
        [ForeignKey("UserId")]
        public Usuario Usuario { get; set;}
        public int UserId { get; set; }

    }
}
