using DataLayer.Model;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PedidoBL
    {
        public bool CrearPedido(Pedido pedido)
        {
            PedidoRepository pedidoRepository = new PedidoRepository();
            return pedidoRepository.Create(pedido);
        }

        public bool UpdatePedido(Pedido pedido)
        {
            PedidoRepository pedidoRepository = new PedidoRepository();
            return pedidoRepository.Update(pedido);
        }

        public bool CreateAndUpdatePedido(Pedido pedido, List<Producto> carrito)
        {
            if (CrearPedido(pedido))
            {
                pedido.Producto = carrito;
                if (UpdatePedido(pedido)){
                    return true;
                }
            }
            return false;
        }
    }
}
