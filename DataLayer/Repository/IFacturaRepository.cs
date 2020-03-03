using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IFacturaRepository
    {
        List<Factura> GetAllFacturasByIdUser(int idUser);
        Factura GetFacturaById(int id);
    }
}
