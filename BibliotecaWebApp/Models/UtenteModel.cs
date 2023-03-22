namespace BibliotecaWebApp.Models
{
    public class UtenteModel
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public Guid ID_Libro { get; set; }
        public DateTime Data_Inserimento_Record { get; set; }
        public bool Stato_Record { get; set; }
    }
}
