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

        [Route("Home/Inicio/{page?}/{pageSize?}")]
        [Route("/")]
        public IActionResult Inicio(int page = 1, int pageSize = 12)
        {
            ProductosVM productosVM = new ProductosVM();

            int skip = (page - 1) * pageSize;

            productosVM.Productos = _context.Productos.Skip(skip).Take(pageSize).ToList();
            productosVM.Categorias = _context.Categorias.ToList();
            productosVM.Marcas = _context.Marcas.ToList();

            productosVM.TotalCount = productosVM.Productos.Count;

            productosVM.PageNumber = page;
            productosVM.PageSize = pageSize;
            return View(productosVM);
        }


        public IActionResult Nosotros()
        {
            return View();
        }


        public IActionResult Cart()
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
        public IActionResult Detalles(int IdProducto)
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