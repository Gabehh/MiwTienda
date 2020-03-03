using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IPedidoRepository
    {
        bool CreatePedidoWithProducts(Pedido pedido);
        Pedido GetPedido(int id);
    }
}
