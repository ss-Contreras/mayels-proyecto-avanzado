using TiendaWebV01.Models;

namespace TiendaWebV01.ViewModels
{
    public class ProductosVM
    {
        public List<Productos> Productos { get; set; }
        public List<Productos> ProductosByIdCategoria { get; set; }
        public List<Categorias> Categorias { get; set; }
        public List<Marcas> Marcas { get; set; }
        
        // Paginacion
        
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
