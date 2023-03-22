using BibliotecaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWebApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> IL NOME DEVE CORRISPONDERE A QUELLO DELLA TABELLA NEL DB <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public DbSet<CategorieModel> Categoria_Immagine_Libro { get; set; }
        public DbSet<LibroModel> Libro { get;set; }
        public DbSet<StatoLibroModel> Stato_Libro { get; set;}
        public DbSet<UtenteModel> Utenti_Tesserati { get; set; }
    }
}