using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IClienteRepository
    {
        bool CheckEmail(string email);
        bool CreateCliente(Cliente cliente);
    }
}
