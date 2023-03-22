using BibliotecaWebApp.Database;
using BibliotecaWebApp.Models;
using BibliotecaWebApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWebApp.Controllers
{
    public class ListaUtentiController : Controller
    {
        private readonly GetExternalAPIBiblioteca _externalAPIBiblioteca;
        private readonly AppDbContext _appDbContext;

        public ListaUtentiController(GetExternalAPIBiblioteca externalAPIBiblioteca, AppDbContext appDbContext)
        {
            _externalAPIBiblioteca = externalAPIBiblioteca;
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _externalAPIBiblioteca.GetUtentiAttivi();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AggiungiUtente(string nome, string cognome, string indirizzo, string ISBN)
        {
            //RICEVO IL MIO ISBN E TRAMITE EFW MI CERCO IL LIBRO ASSOCIATO AL MIO ISBN
            LibroModel libro = await _appDbContext.Libro.Where(libro => libro.ISBN == ISBN).FirstAsync();

            UtenteModel newUtente = new UtenteModel();
            newUtente.Nome = nome;
            newUtente.Cognome = cognome;
            newUtente.Indirizzo = indirizzo;
            //UNA VOLTA TROVATO IL LIBRO ASSOCIATO ALL'ISBN, PASSO L'ID DEL LIBRO AL NUOVO UTENTE
            newUtente.ID_Libro = libro.ID;
            newUtente.Data_Inserimento_Record = DateTime.Now;
            newUtente.Stato_Record = true;

            _appDbContext.Utenti_Tesserati.Add(newUtente);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EliminaUtenti(List<Guid> idUtenti)
        {
            if (idUtenti.Count > 0)
            {
              foreach (Guid id in idUtenti)
              {
                    UtenteModel utente = await _appDbContext.Utenti_Tesserati.FirstAsync(c => c.ID == id);
                    _appDbContext.Utenti_Tesserati.Remove(utente);
                    _appDbContext.SaveChanges();
              }
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
