﻿using BusinessLayer;
using MiwTienda.Models;
using System.Linq;
using System.Web.Mvc;

namespace MiwTienda.Controllers
{
    [Authorize]
    public class CarritoController : Controller
    {
        // GET: Carrito
        [HttpGet]
        public ActionResult Index(CarritoCompra carrito)
        {
            if (carrito.clickPay)
            {
                ModelState.AddModelError("", "No hay articulos en el carrito");
                carrito.clickPay = false;
            }

            var productos = carrito.GroupBy(u => u.Id)
                                   .Select(x => new ProductoViewModel 
                                   {
                                       cantidadComprar = x.Count(), 
                                       id = x.First().Id, 
                                       descripcion = x.First().Descripcion, 
                                       imagen = x.First().Imagen,
                                       nombre = x.First().Nombre,
                                       valor = x.First().Precio * x.Count()
                                   });
            CarritoViewModels cesta = new CarritoViewModels { carrito = productos.ToList() };
            return View(cesta);
        }

        public ActionResult AddProducto(CarritoCompra carrito, ProductoViewModel producto)
        {
            ProductoBL productoBL = new ProductoBL();
            var _producto = productoBL.GetProductoById(producto.id);
            for (int x = 0; x < producto.cantidadComprar; x++)
            {
                carrito.Add(_producto);
            }
            return RedirectToAction("Index", "Producto");
        }

        public ActionResult DeleteAll(CarritoCompra carrito)
        {
            carrito.Clear();
            return RedirectToAction("Index", "Carrito");
        }

        public ActionResult CheckCarrito(CarritoCompra carrito)
        {
            if (carrito.Count > 0)
            {
                return RedirectToAction("Index", "Pedido");
            }
            else
            {
                carrito.clickPay = true;
                return RedirectToAction("Index", "Carrito");
            }
        }
    }
}