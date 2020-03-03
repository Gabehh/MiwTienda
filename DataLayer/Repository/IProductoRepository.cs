using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IProductoRepository
    {
        bool UpdateMultiplesStock(IDictionary<int, int> productosNewStock);
    }
}
