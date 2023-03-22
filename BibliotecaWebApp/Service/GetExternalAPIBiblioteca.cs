using BibliotecaWebApp.Database;
using BibliotecaWebApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace BibliotecaWebApp.Service
{
    public class GetExternalAPIBiblioteca
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _appDbContext;
        public GetExternalAPIBiblioteca(HttpClient httpClient, AppDbContext context)
        {
            _httpClient = httpClient;
            _appDbContext = context;
        }

        public async Task<List<LibroAPIModel>> GetLibriByCategoria(string categoria)
        {
            JsonValue result = await _httpClient.GetFromJsonAsync<JsonValue>("https://localhost:7077/Biblioteca/GetLibroByCategoria?categoria=" + categoria);
            List<JObject> jsonObjResult = JsonConvert.DeserializeObject<List<JObject>>(result.ToString());

            List<LibroAPIModel> libri = new List<LibroAPIModel>();
            foreach (var item in jsonObjResult)
            {
                LibroAPIModel libro = new LibroAPIModel();
                libro.Nome_Libro = item["nome_Libro"].ToString();
                libro.Categoria_Libro = item["categoria_Libro"].ToString();
                libro.Anno_Pubblicazione = Convert.ToInt32(item["anno_Pubblicazione"]);
                libro.ISBN = item["isbn"].ToString();
                libro.Stato_Libro = item["stato_Libro"].ToString();
                libro.Numero_Copie_Presenti = Convert.ToInt32(item["numero_Copie_Presenti"]);
                libri.Add(libro);
            }

            return libri;
        }

        public async Task<List<UtenteModelDTO>> GetUtentiAttivi()
        {
            JsonValue result = await _httpClient.GetFromJsonAsync<JsonValue>("https://localhost:7077/Utente/GetUtentiAttivi");
            List<JObject> jsonObjResult = JsonConvert.DeserializeObject<List<JObject>>(result.ToString());

            List<UtenteModelDTO> utenti = new List<UtenteModelDTO>();
            foreach(var item in jsonObjResult)
            {
                UtenteModelDTO utente = new UtenteModelDTO();
                utente.ID = Guid.Parse(item["id"].ToString());
                utente.Nome = item["nome_Utente"].ToString();
                utente.Cognome = item["cognome_Utente"].ToString();
                utente.Indirizzo = item["indirizzo"].ToString();
                utente.ISBN = item["libro"].ToString();
                utenti.Add(utente);
            }
            return utenti;
        }
    }
}
