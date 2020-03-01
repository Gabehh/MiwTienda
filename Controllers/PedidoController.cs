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
        public ActionResult Index()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var id = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => c.Value).SingleOrDefault();
            var user = new AccountBL().GetClienteById(Convert.ToInt32(id));
            var metodos = new PagoBL().GetMetodoPagos();
            var pedidoViewModel = new PedidoViewModels() { cliente = user, metodoPago = metodos };
            return View(pedidoViewModel);
        }

        public ActionResult Compra()
        {
            return View();
        }
    }
}