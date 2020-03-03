using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class FacturaRepository : BaseRepository<Factura>, IFacturaRepository
    {
        public List<Factura> GetAllFacturasByIdUser(int idUser)
        {
            ModelContainer1 modelContainer1 = new ModelContainer1();
            return modelContainer1.FacturaSet.Where(u => u.Pedido.ClienteId == idUser).ToList();
        }

        public Factura GetFacturaById(int id)
        {
            ModelContainer1 modelContainer1 = new ModelContainer1();
            return modelContainer1.FacturaSet.Single(u => u.Id == id);
        }
    }
}
