using System.ComponentModel.DataAnnotations;

namespace GestionEscuelaTarea.Models
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; } // Atributo 1

        [Required]
        public string Nombre { get; set; } // Atributo 2

        [Required]
        public string Especialidad { get; set; } // Atributo 3

        public string Telefono { get; set; } // Atributo 4

        public string Email { get; set; } // Atributo 5
    }
}