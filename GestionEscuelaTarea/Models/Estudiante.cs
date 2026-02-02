using System.ComponentModel.DataAnnotations;

namespace GestionEscuelaTarea.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; } // Atributo 1 (ID)

        [Required]
        public string Nombre { get; set; } // Atributo 2

        [Required]
        public string Apellido { get; set; } // Atributo 3

        [Required]
        public string Cedula { get; set; } // Atributo 4

        public string Email { get; set; } // Atributo 5
    }
}