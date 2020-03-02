using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IPedidoRepository
    {
        bool UpdateMultiplesStock(IDictionary<int, int> productosNewStock);
    }
}
