namespace BibliotecaWebApp.Models
{
    public class LibroAPIModel
    {
            public string Nome_Libro { get; set; }
            public string Categoria_Libro { get; set; }
            public int Anno_Pubblicazione { get; set; }
            public string ISBN { get; set; }
            public string Stato_Libro { get; set; }
            public int Numero_Copie_Presenti { get; set; }
    }
}
