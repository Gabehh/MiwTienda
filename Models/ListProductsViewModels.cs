using DataLayer.Model;
using System.Collections.Generic;

namespace MiwTienda.Models
{
    public class ListaProductoViewModel
    {
        public string palabraClave { get; set; }
        public List<Producto> productos { get; set; }
    }

    public class ProductoViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double valor { get; set; }
        public string imagen { get; set; }
        public int stock { get; set; }
        public int cantidadComprar { get; set; }
    }

    public class CarritoViewModel
    {
        public List<ProductoViewModel> carrito { get; set; }
    }
}