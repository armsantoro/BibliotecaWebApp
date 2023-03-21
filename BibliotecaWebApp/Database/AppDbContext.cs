using BibliotecaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWebApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CategorieModel> Categoria_Immagine_Libro { get; set; }
        public DbSet<LibroModel> Libro { get;set; }
        
    }
}