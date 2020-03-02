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

        public Producto GetProductoById(int id)
        {
            ProductoRepository productoRespository = new ProductoRepository();
            return productoRespository.Single(u => u.Id == id);
        }

        public bool UpdateStock(IDictionary<int,int> productosNewStock)
        {
            return new ProductoRepository().UpdateMultiplesStock(productosNewStock);
        }
    }
}
