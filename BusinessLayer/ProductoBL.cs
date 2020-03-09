using DataLayer.Model;
using DataLayer.Repository;
using System;
using System.Collections.Generic;

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

        public List<Producto> GetProductosByCategory(int categoria)
        {
            ProductoRepository productoRespository = new ProductoRepository();
            return productoRespository.Filter(u => u.Categoria == categoria);

        }

        public Producto GetProductoById(int id)
        {
            ProductoRepository productoRespository = new ProductoRepository();
            return productoRespository.Single(u => u.Id == id);
        }

        public bool CreateProduct(Producto producto)
        {
            ProductoRepository productoRespository = new ProductoRepository();
            return productoRespository.Create(producto);
        }

        public bool Update(Producto producto)
        {
            ProductoRepository productoRespository = new ProductoRepository();
            return productoRespository.Update(producto);
        }

        public bool Delete(Producto producto)
        {
            ProductoRepository productoRespository = new ProductoRepository();
            return productoRespository.Delete(producto);
        }

        public bool UpdateStock(IDictionary<int,int> productosNewStock)
        {
            return new ProductoRepository().UpdateMultiplesStock(productosNewStock);
        }

        public List<Producto> GetProductosLowStock()
        {
            ProductoRepository productoRespository = new ProductoRepository();
            return productoRespository.Filter(u => u.Cantidad <= 2);
        }
    }
}
