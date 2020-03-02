using BusinessLayer;
using MiwTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiwTienda.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto

        public ActionResult Index(string palabraClave)
        {
            try
            {
                var productos = new ProductoBL().GetProductosByWord(palabraClave);
                ListaProductoViewModel producto = new ListaProductoViewModel() { productos = productos, palabraClave = palabraClave };
                return View(producto);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var producto = new ProductoBL().GetProductoById(id);
            ProductoViewModel productoView = new ProductoViewModel
            {
                id = producto.Id,
                nombre = producto.Nombre,
                descripcion = producto.Descripcion,
                imagen = producto.Imagen,
                stock = producto.Cantidad,
                valor = producto.Precio
            };
            return View(productoView);
        }

        [HttpPost]
        public ActionResult Detail(ProductoViewModel producto)
        {
            if (producto.cantidadComprar == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar la cantidad");
                return View(producto);
            }
            else if (producto.cantidadComprar > producto.stock )
            {
                ModelState.AddModelError("", "El Stock es insuficiente.");
                return View(producto);
            }
            return RedirectToAction("AddProducto", "Carrito", producto);
        }
    }
}