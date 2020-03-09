using DataLayer.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

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

    public class CarritoViewModels
    {
        public List<ProductoViewModel> carrito { get; set; }
    }

    public class ProductCreateViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name="Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Valor")]
        public double valor { get; set; }
        public string rutaImagen { get; set; }
        [Required]
        [Display(Name = "Stock")]
        public int stock { get; set; }
        [Display(Name = "Imagen")]
        public HttpPostedFileBase imagen { get; set; }
        [Required]
        [Display(Name = "Categoría")]
        public int categoria { get; set; }
    }

    public class Abastecimiento
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public string mensaje { get; set; }
    }

    public class ListAbastecimientoViewModel
    {
        public List<Abastecimiento> listaStock {get;set;}
    }
}