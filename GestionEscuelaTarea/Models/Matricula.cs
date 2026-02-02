using System.ComponentModel.DataAnnotations;

namespace GestionEscuelaTarea.Models
{
    public class Matricula
    {
        [Key]
        public int Id { get; set; } // Atributo 1

        [Required]
        [Display(Name = "Fecha de Inscripción")]
        public DateTime Fecha { get; set; } // Atributo 2

        [Required]
        public string Periodo { get; set; } // Atributo 3 (ej: 2026-01)

        [Range(0, 10)]
        public double NotaFinal { get; set; } // Atributo 4

        public bool EstaPagado { get; set; } // Atributo 5
    }
}