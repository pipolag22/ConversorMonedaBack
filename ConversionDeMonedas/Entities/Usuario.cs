using ConversionDeMonedas.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ConversionDeMonedas.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Contrasenia { get; set; }

        [Required]
        public Suscripcion Suscripcion { get; set; }

        public int TotalConversiones { get; set; }
    }
   
}
