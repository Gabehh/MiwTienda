using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        public bool UpdateMultiplesStock(IDictionary<int, int> productosNewStock)
        {
            using (ModelContainer1 context = new ModelContainer1())
            {
                foreach (var productoNewStock in productosNewStock)
                {
                    Producto producto = context.ProductoSet.Single(u=>u.Id == productoNewStock.Key);
                    producto.Cantidad = producto.Cantidad - productoNewStock.Value;
                }
                return context.SaveChanges()>0;
            }
        }
    }
}
