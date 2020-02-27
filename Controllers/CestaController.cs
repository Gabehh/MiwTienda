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
    public class CestaController : ApiController
    {
        public HttpResponseMessage GetAll(CarritoCompra carrito)
        {
            try
            {
                HttpResponseMessage content = new HttpResponseMessage();
                var lista = carrito.Select(u => new string[]
                            {
                                u.Nombre,
                                u.Descripcion,
                                u.Precio.ToString() + "€",
                                u.Imagen
                            }).ToList();
                content.StatusCode = HttpStatusCode.OK;
                content.Content = new StringContent(JsonConvert.SerializeObject(lista));
                content.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return content;
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

    }
}
