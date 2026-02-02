using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GestionEscuelaTarea.Models;
using GestionEscuelaTarea.Data;
using GestionEscuelaTarea.Areas.Identity.Data;

namespace GestionEscuelaTarea
{
    public class Program
    {
        public static async Task Main(string[] args) // Cambiado a Task para inicializar roles
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Configurar la conexión a MySQL (XAMPP)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // 2. Configurar Identity con Roles y Usuario Personalizado
            builder.Services.AddDefaultIdentity<GestionEscuelaTareaUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddRoles<IdentityRole>() // <--- HABILITA EL USO DE ROLES
            .AddEntityFrameworkStores<ApplicationDbContext>();

            // 3. Agregar servicios de MVC y Razor Pages
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // --- INICIO DEL BLOQUE PARA CREAR ROLES AUTOMÁTICAMENTE ---
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roleNames = { "Administrador", "Alumno" };
                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
            // --- FIN DEL BLOQUE DE ROLES ---

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // 4. El orden es sagrado
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}