using DataLayer.Model;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PagoBL
    {
        public List<MetodoPago> GetMetodoPagos()
        {
            PagoRepository pagoRepository = new PagoRepository();
            return pagoRepository.GetAll();
        }

        public string GetNameMethod(int id)
        {
            PagoRepository pagoRepository = new PagoRepository();
            return pagoRepository.Single(u => u.Id == id)?.TipoMetodo;
        }

    }
}
