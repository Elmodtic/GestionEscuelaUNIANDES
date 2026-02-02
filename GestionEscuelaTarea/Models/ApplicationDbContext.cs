using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestionEscuelaTarea.Models;
using GestionEscuelaTarea.Areas.Identity.Data;

namespace GestionEscuelaTarea.Data
{
    // Heredamos de IdentityDbContext para que el sistema reconozca a GestionEscuelaTareaUser
    public class ApplicationDbContext : IdentityDbContext<GestionEscuelaTareaUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Ajustado según tu imagen image_06b213.png
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}