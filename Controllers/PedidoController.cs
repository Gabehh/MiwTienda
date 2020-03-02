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

        public ActionResult Compra(CarritoCompra carrito, PedidoViewModels pedidoViewModels)
        {
            Pedido pedido = new Pedido()
            {
                ClienteId = pedidoViewModels.cliente.Id,
                EstadoId = 1,//facturado
                Factura = new Factura()
                {
                    Fecha = DateTime.Now,
                    MetodoPagoId = pedidoViewModels.methodPay
                }              
            };
            if(new PedidoBL().CreateAndUpdatePedido(pedido, carrito))
            {
                // Reducir Stock
                var productosForUpdate = carrito.GroupBy(u => u.Id)
                                        .Select(x => new 
                                        {
                                            cantidadComprar = x.Count(),
                                            id = x.First().Id,
                                        }).ToDictionary(x=>x.id, x=>x.cantidadComprar);
                if(new ProductoBL().UpdateStock(productosForUpdate))
                {
                    carrito.Clear();
                    return View();
                }

            }   
            return View();
        }
    }
}