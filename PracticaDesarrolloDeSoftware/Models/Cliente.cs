using System.ComponentModel.DataAnnotations;

namespace PracticaDesarrolloDeSoftware.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "RFC Obligatoria")]
        public string RFC { get; set; }
        [Required(ErrorMessage = "Direccion Obligatorio")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Ciudad Obligatorio")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Codigo Postal Obligatorio")]
        public int CodigoPostal { get; set; }
    }
}
