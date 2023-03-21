using BibliotecaWebApp.Database;
using BibliotecaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWebApp.Controllers
{
    public class HomeBibliotecaController : Controller
    {
        private readonly AppDbContext _context;
        public HomeBibliotecaController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<CategorieModel> categorieModels = await _context.Categoria_Immagine_Libro.AsNoTracking().ToListAsync();
            return View(categorieModels);
        }

        [HttpPost]
        public IActionResult AggiungiCategoria(string genere, IFormFile immagine)
        {
            CategorieModel newCategoria = new CategorieModel(genere);
            if (immagine != null)
            {
                using (var ms = new MemoryStream())
                {
                    immagine.CopyTo(ms);
                    newCategoria.Immagine = ms.ToArray();
                }
            }
            _context.Categoria_Immagine_Libro.Add(newCategoria);
            _context.SaveChanges();
            return RedirectToAction("Index", "HomeBiblioteca");
        }

        public IActionResult RimuoviCategoria(Guid id)
        {
            CategorieModel categoria = _context.Categoria_Immagine_Libro.FirstOrDefault(c => c.ID == id);
            if (categoria != null)
            {
                _context.Categoria_Immagine_Libro.Remove(categoria);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
