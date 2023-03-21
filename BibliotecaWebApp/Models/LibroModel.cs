namespace BibliotecaWebApp.Models
{
    public class LibroModel
    {
        public Guid ID { get; set; }
        public string Nome_Libro { get; set; }
        public Guid ID_Categoria_Libro { get; set; }
        public int Anno_Pubblicazione { get; set; }
        public string ISBN { get; set; }
        public Guid ID_Stato_Libro { get; set; }
        public int Numero_Copie_Presenti { get; set; }
        public DateTime Data_Inserimento_Record { get; set; }
        public bool Stato_Record { get; set; }
    }
}
