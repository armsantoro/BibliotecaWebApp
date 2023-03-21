using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApp.Models
{
    public class CategorieModel
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Genere { get; set; }
        public byte[]? Immagine { get; set; } 
        public CategorieModel(string genere) 
        {
            Genere = genere;
        }
    }
}
