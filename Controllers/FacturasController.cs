using BusinessLayer;
using MiwTienda.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MiwTienda.Controllers
{
    public class FacturasController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetAllByUser(int idUser)
        {
            try
            {
                HttpResponseMessage content = new HttpResponseMessage();
                var lista = new FacturaBL().GetAllFacturasByUser(idUser)
                                           .Select(u => new string[]
                                           {
                                               "<a href='#' onClick='PrintPdf("+ u.Id+")'> "+u.Id+" </a>",
                                               u.Fecha.ToString(),
                                               u.MetodoPago.TipoMetodo,
                                               u.Pedido.Producto.Sum(x=>x.Precio).ToString() + " €"
                                           }); 
                content.StatusCode = HttpStatusCode.OK;
                content.Content = new StringContent(JsonConvert.SerializeObject(lista));
                content.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return content;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                HttpResponseMessage content = new HttpResponseMessage();
                var factura = new FacturaBL().GetFacturaById(id);
                var facturaPdf = new
                {
                    cliente = factura.Pedido.Cliente.Nombre,
                    direccion = factura.Pedido.Cliente.Direccion,
                    fecha = factura.Fecha,
                    productos = factura.Pedido.Producto.Select(u=> new { nombre = u.Nombre, precio = u.Precio }).ToList(),
                    total = factura.Pedido.Producto.Sum(u => u.Precio),
                    numero = factura.Id,
                    metodoPago = factura.MetodoPago.TipoMetodo
                };
                content.StatusCode = HttpStatusCode.OK;
                content.Content = new StringContent(JsonConvert.SerializeObject(facturaPdf));
                content.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return content;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

    }
}
