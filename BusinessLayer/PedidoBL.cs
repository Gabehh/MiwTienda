using DataLayer.Model;
using DataLayer.Repository;

namespace BusinessLayer
{
    public class PedidoBL
    {

        public Pedido GetPedido(int id)
        {
            PedidoRepository pedidoRepository = new PedidoRepository();
            return pedidoRepository.GetPedido(id);
        }

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

        public bool CreatePedidoProductos(Pedido pedido)
        {
            PedidoRepository pedidoRepository = new PedidoRepository();
            return pedidoRepository.CreatePedidoWithProducts(pedido);
        }
    }
}
