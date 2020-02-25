using DataLayer.Model;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductoBL
    {
        public List<Producto> GetProductosByWord(string palabra)
        {
            ProductoRepository productoRespository = new ProductoRepository();
            var productos = String.IsNullOrEmpty(palabra) ? productoRespository.GetAll() : productoRespository.Filter(u => u.Nombre.Contains(palabra) || u.Descripcion.Contains(palabra));
            return productos;
        }
    }
}
