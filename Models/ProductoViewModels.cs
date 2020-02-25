using DataLayer.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiwTienda.Models
{
    public class ProductoViewModel
    {
        public string palabraClave { get; set; }
        public List<Producto> productos { get; set; }
    }
}