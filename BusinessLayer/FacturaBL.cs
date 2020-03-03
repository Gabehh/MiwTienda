using DataLayer.Model;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FacturaBL
    {
        public List<Factura> GetAllFacturasByUser(int idUser)
        {
            FacturaRepository repository = new FacturaRepository();
            return repository.GetAllFacturasByIdUser(idUser);
        }

        public Factura GetFacturaById(int idFactura)
        {
            FacturaRepository repository = new FacturaRepository();
            return repository.GetFacturaById(idFactura);
        }
    }
}
