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
        public ActionResult Index(ProductoViewModel producto)
        {
            try
            {
                var productos = new ProductoBL().GetProductosByWord(producto.palabraClave);
                producto.productos = productos;
                return View(producto);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }
    }
}