using BusinessLayer;
using DataLayer.Model;
using MiwTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MiwTienda.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index(CarritoCompra carrito)
        {
            if (carrito.Count == 0) return RedirectToAction("Index", "Home");
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var id = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => c.Value).SingleOrDefault();
            var user = new AccountBL().GetClienteById(Convert.ToInt32(id));
            var metodos = new PagoBL().GetMetodoPagos();
            var pedidoViewModel = new PedidoViewModels() { cliente = user, metodoPago = metodos };
            return View(pedidoViewModel);
        }

        [HttpGet]
        public ActionResult MisFacturas()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var id = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => c.Value).SingleOrDefault();
            TempData["id"] = id.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult Compra(CarritoCompra carrito, PedidoViewModels pedidoViewModels)
        {
            if (carrito.Count > 0)
            {
                PedidoBL pedidoBL = new PedidoBL();
                Pedido pedido = new Pedido()
                {
                    ClienteId = pedidoViewModels.cliente.Id,
                    EstadoId = 1,//facturado
                    Factura = new Factura()
                    {
                        Fecha = DateTime.Now,
                        MetodoPagoId = pedidoViewModels.methodPay
                    },
                    Producto = carrito.OrderBy(u=>u.Id).ToArray()
                };
                if (pedidoBL.CreatePedidoProductos(pedido))
                {
                    //REFRESCAR PEDIDO (SE PUEDE HACER MEJOR)
                    pedido = pedidoBL.GetPedido(pedido.Id);
                    // Reducir Stock
                    var productosForUpdate = carrito.GroupBy(u => u.Id)
                                            .Select(x => new
                                            {
                                                cantidadComprar = x.Count(),
                                                id = x.First().Id,
                                            }).ToDictionary(x => x.id, x => x.cantidadComprar);
                    if (new ProductoBL().UpdateStock(productosForUpdate))
                    {
                        pedido.Factura.MetodoPago = pedido.Factura.MetodoPago;
                        pedido.Factura.Pedido.Cliente = pedido.Cliente;
                        FacturaViewModels factura = new FacturaViewModels() { factura = pedido.Factura };
                        carrito.Clear();
                        return View(factura);
                    }
                }
            }
            return View("Error");
        }
    }
}