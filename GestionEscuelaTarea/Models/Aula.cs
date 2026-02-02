using System.ComponentModel.DataAnnotations;

namespace GestionEscuelaTarea.Models
{
    public class Aula
    {
        [Key]
        public int Id { get; set; } // Atributo 1

        [Required]
        [Display(Name = "Nombre del Aula")]
        public string Nombre { get; set; } // Atributo 2

        [Required]
        public string Ubicacion { get; set; } // Atributo 3 (ej: Edificio A)

        public int Capacidad { get; set; } // Atributo 4

        public bool TieneProyector { get; set; } // Atributo 5
    }
}