using System.ComponentModel.DataAnnotations;

namespace TiendaWebV01.Models
{
    public class Marcas
    {
        [Key]
        public string IdMarca { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
