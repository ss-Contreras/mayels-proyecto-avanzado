using Microsoft.AspNetCore.Mvc;
using TiendaWebV01.Data;
using TiendaWebV01.Models;
using TiendaWebV01.ViewModels;

namespace TiendaWebV01.Controllers
{
	public class HomeController : Controller
	{
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Inicio()
		{
			return View();
		}

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult Productos()
        {
            ProductosVM productosVM = new ProductosVM();
            productosVM.Productos = _context.Productos.ToList();
            productosVM.Categorias = _context.Categorias.ToList();
            productosVM.Marcas = _context.Marcas.ToList();
            return View(productosVM);
        }

        [Route("Home/ProductosByCategoria")]
        public async Task<IActionResult> ProductosByCategoria(string IdCategoria, string IdMarca)
        {
            ProductosVM productosVM = new ProductosVM();
            if (IdCategoria == "All")
            {
                if (IdMarca == "All")
                {
                    productosVM.Productos = _context.Productos.ToList();
                }
                else
                {
                    productosVM.Productos = _context.Productos.Where(p => p.IdMarca == IdMarca).ToList();
                }

            }
            else
            {
                if (IdMarca == "All")
                {
                    productosVM.Productos = _context.Productos.Where(p => p.IdCategoria == IdCategoria).ToList();
                }
                else
                {
                    productosVM.Productos = _context.Productos.Where(p => p.IdCategoria == IdCategoria)
                                                              .Where(p => p.IdMarca == IdMarca).ToList();
                }

            }

            

            return PartialView("Partials/_productos", productosVM);
        }

        [Route("Home/ProductosByMarca")]
        public async Task<IActionResult> ProductosByMarca(string IdCategoria, string IdMarca)
        {
            ProductosVM productosVM = new ProductosVM();
            if (IdCategoria == "All")
            {
                if(IdMarca == "All")
                {
                    productosVM.Productos = _context.Productos.ToList();
                }
                else
                {
                    productosVM.Productos = _context.Productos.Where(p => p.IdMarca == IdMarca).ToList();
                }
                
            }
            else
            {
                if (IdMarca == "All")
                {
                    productosVM.Productos = _context.Productos.Where(p => p.IdCategoria == IdCategoria).ToList();
                }
                else
                {
                    productosVM.Productos = _context.Productos.Where(p => p.IdCategoria == IdCategoria)
                                                              .Where(p => p.IdMarca == IdMarca).ToList();
                }
                
            }

            return PartialView("Partials/_productos", productosVM);
        }

        [Route("Home/Detalles/{IdProducto}")]
        public IActionResult Detalles(string IdProducto)
        {
            Productos producto = new Productos();
            producto = _context.Productos.FirstOrDefault(p => p.IdProducto == IdProducto);
            return View(producto);
        }

        public IActionResult Contacto()
        {
            return View();
        }


    }
}