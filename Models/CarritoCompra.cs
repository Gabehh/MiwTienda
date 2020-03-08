using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiwTienda.Models
{
    public class CarritoCompra : List<Producto>
    {
        public bool clickPay { get; set; } = false;
        public int idUser { get; set; }
    }
}