using TiendaWebV01.Models;

namespace TiendaWebV01.ViewModels
{
    public class ProductosVM
    {
        public List<Productos> Productos { get; set; }
        public List<Productos> ProductosByIdCategoria { get; set; }
        public List<Categorias> Categorias { get; set; }
        public List<Marcas> Marcas { get; set; }
    }
}
