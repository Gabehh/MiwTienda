using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiwTienda.Models
{
    public class PedidoViewModels
    {
        public Cliente cliente { get; set; }
        public List<MetodoPago> metodoPago { get; set; }
        public int metodoSeleccionado { get; set; }
    }
}