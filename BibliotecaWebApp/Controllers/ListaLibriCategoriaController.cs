using BibliotecaWebApp.Database;
using BibliotecaWebApp.Models;
using BibliotecaWebApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApp.Controllers
{
    public class ListaLibriCategoriaController : Controller
    {
        private readonly GetExternalAPIBiblioteca _externalAPIBiblioteca;
        private readonly AppDbContext _appDbContext;
        public ListaLibriCategoriaController(GetExternalAPIBiblioteca getExternalAPIBiblioteca, AppDbContext context)
        {
            _externalAPIBiblioteca = getExternalAPIBiblioteca;
            _appDbContext = context;
        }


        public async Task<IActionResult> Index(string genere)
        {
            var result = await _externalAPIBiblioteca.GetLibriByCategoria(genere);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AggiungiLibro(string nomeLibro, string catLibro, int annoPub, string isbn, Guid statoLib, int numCopie)
        {
            CategorieModel categoriaLibro = _appDbContext.Categoria_Immagine_Libro.Where(categoria => categoria.Genere == catLibro).First();
            LibroModel newLibro = new LibroModel();
            newLibro.Nome_Libro = nomeLibro;
            newLibro.ID_Categoria_Libro = categoriaLibro.ID;
            newLibro.Anno_Pubblicazione = annoPub;
            newLibro.ISBN = isbn;
            newLibro.ID_Stato_Libro = statoLib;
            newLibro.Numero_Copie_Presenti = numCopie;
            newLibro.Data_Inserimento_Record = DateTime.Now;
            newLibro.Stato_Record = true;

            _appDbContext.Libro.Add(newLibro);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index", "ListaLibriCategoria", new {categoriaLibro.Genere});
        }  
    }
}