using System.ComponentModel.DataAnnotations;

namespace GestionEscuelaTarea.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; } // Atributo 1

        [Required]
        public string NombreCurso { get; set; } // Atributo 2

        [Required]
        public string Codigo { get; set; } // Atributo 3

        public int Creditos { get; set; } // Atributo 4

        public string Descripcion { get; set; } // Atributo 5
    }
}