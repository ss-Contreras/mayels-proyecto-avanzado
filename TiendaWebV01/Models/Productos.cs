using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaWebV01.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }

        public string IdCategoria { get; set; }

        public string IdMarca { get; set; }
        public string Ruta { get; set; }
        

    }
}
