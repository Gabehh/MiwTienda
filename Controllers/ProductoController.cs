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

        [ActionName("OverloadedActionName")]
        public ActionResult Detail(ProductoViewModel producto)
        {
            return View(producto);
        }

        [HttpPost]
        public ActionResult AgregarCarrito(ProductoViewModel producto)
        {
            if (producto.cantidadComprar == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar la cantidad");
                return View("Detail", producto);
            }
            else if (producto.cantidadComprar > producto.stock )
            {
                ModelState.AddModelError("", "El Stock es insuficiente.");
                return View("Detail", producto);
            }
            return RedirectToAction("AddProducto", "Carrito", producto);
        }
    }
}