using BibliotecaWebApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace BibliotecaWebApp.Service
{
    public class GetExternalAPIBiblioteca
    {
        private readonly HttpClient _httpClient;
        public GetExternalAPIBiblioteca(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
    }
}
