﻿using DataLayer.Model;
using System.Data.Entity;
using System.Linq;

namespace DataLayer.Repository
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public bool CreatePedidoWithProducts(Pedido pedido)
        {
            using(ModelContainer1 container1 = new ModelContainer1())
            {
                container1.PedidoSet.Add(pedido);
                pedido.Producto.ToList().ForEach(u => container1.Entry(u).State = EntityState.Unchanged);
                return container1.SaveChanges()>0;
            }
        }

        public Pedido GetPedido(int id)
        {
            ModelContainer1 container1 = new ModelContainer1();
            return container1.PedidoSet.Single(u => u.Id == id);
        }
    }
}
