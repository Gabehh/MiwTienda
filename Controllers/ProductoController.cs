using BusinessLayer;
using DataLayer.Model;
using MiwTienda.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MiwTienda.Controllers
{
    public class ProductoController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult AgregarProducto()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var producto = new ProductoBL().GetProductoById(id);
            string path = System.IO.Path.Combine(
                       Server.MapPath("~/Imagenes/"), producto.Imagen);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            ProductCreateViewModel productCreateViewModel = new ProductCreateViewModel()
            {
                id = producto.Id,
                descripcion = producto.Descripcion,
                nombre = producto.Nombre,
                stock = producto.Cantidad,
                valor = producto.Precio,
                categoria = producto.Categoria??0,
                imagen = new MemoryPostedFile(bytes,producto.Imagen)
            };
            return View(productCreateViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Eliminar(int id)
        {
            var producto = new ProductoBL().GetProductoById(id);
            if(new ProductoBL().Delete(producto))
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Error");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Editar(ProductCreateViewModel _producto)
        {
            if (ModelState.IsValid)
            {
                var producto = new ProductoBL().GetProductoById(_producto.id);
                producto.Nombre = _producto.nombre;
                producto.Cantidad = _producto.stock;
                producto.Descripcion = _producto.descripcion;
                producto.Precio = _producto.valor;
                producto.Categoria = _producto.categoria;

                if (_producto.imagen != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        _producto.imagen.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                    string pic = System.IO.Path.GetFileName(_producto.imagen.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/Imagenes/"), pic);
                    _producto.imagen.SaveAs(path);
                    producto.Imagen = pic;
                }

                if (new ProductoBL().Update(producto))
                    return RedirectToAction("Index", "Home");
                else
                    return View("Error");
            }
            return View(_producto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AgregarProducto(ProductCreateViewModel producto)
        {
            if (producto.imagen == null) ModelState.AddModelError("", "El campo Imagen es obligatorio");
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
                    Precio = producto.valor,
                    Categoria = producto.categoria
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

        public ActionResult Categoria(int categoria)
        {
            try
            {
                var productos = new ProductoBL().GetProductosByCategory(categoria);
                ListaProductoViewModel producto = new ListaProductoViewModel() { productos = productos, palabraClave = "" };
                return View("Index", producto);
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

        protected class MemoryPostedFile : HttpPostedFileBase
        {
            private readonly byte[] fileBytes;

            public MemoryPostedFile(byte[] fileBytes, string fileName = null)
            {
                this.fileBytes = fileBytes;
                this.FileName = fileName;
                this.InputStream = new MemoryStream(fileBytes);
            }

            public override int ContentLength => fileBytes.Length;

            public override string FileName { get; }

            public override Stream InputStream { get; }
        }
    }
}