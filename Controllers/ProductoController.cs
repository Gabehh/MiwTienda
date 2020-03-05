using BusinessLayer;
using DataLayer.Model;
using MiwTienda.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiwTienda.Controllers
{
    public class ProductoController : Controller
    {
        [Authorize]
        public ActionResult AgregarProducto()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var producto = new ProductoBL().GetProductoById(id);
            ProductCreateViewModel productCreateViewModel = new ProductCreateViewModel()
            {
                id = producto.Id,
                descripcion = producto.Descripcion,
                nombre = producto.Nombre,
                stock = producto.Cantidad,
                valor = producto.Precio
            };
            return View(productCreateViewModel);
        }

        [Authorize]
        public ActionResult Eliminar(int id)
        {
            var producto = new ProductoBL().GetProductoById(id);
            if(new ProductoBL().Delete(producto))
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Error");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Editar(ProductCreateViewModel _producto)
        {
            if (ModelState.IsValid)
            {
                var producto = new ProductoBL().GetProductoById(_producto.id);
                string pic = System.IO.Path.GetFileName(_producto.imagen.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Imagenes/"), pic);
                _producto.imagen.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    _producto.imagen.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                producto.Nombre = _producto.nombre;
                producto.Cantidad = _producto.stock;
                producto.Descripcion = _producto.descripcion;
                producto.Precio = _producto.valor;
                producto.Imagen = pic;

                if (new ProductoBL().Update(producto))
                    return RedirectToAction("Index", "Home");
                else
                    return View("Error");
            }
            return View(_producto);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AgregarProducto(ProductCreateViewModel producto)
        {
            if (ModelState.IsValid)
            {
                string pic = System.IO.Path.GetFileName(producto.imagen.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Imagenes/"), pic);
                producto.imagen.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    producto.imagen.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                Producto newProduct = new Producto
                {
                    Nombre = producto.nombre,
                    Descripcion = producto.descripcion,
                    Cantidad = producto.stock,
                    Imagen = pic,
                    Precio = producto.valor
                };
                if (new ProductoBL().CreateProduct(newProduct))
                    return RedirectToAction("Index", "Home");
                else
                    return View("Error");
            }
            return View(producto);
        }

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