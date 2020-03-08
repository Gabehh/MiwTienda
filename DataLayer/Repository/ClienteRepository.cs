using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public bool CheckEmail(string email)
        {
            using (ModelContainer1 context = new ModelContainer1())
            {
                return context.ClienteSet.Any(u => u.Email == email);
            }
        }

        public bool CreateCliente(Cliente cliente)
        {
            using (ModelContainer1 context = new ModelContainer1())
            {
                context.ClienteSet.Add(cliente);
                cliente.Rol.ToList().ForEach(u => context.Entry(u).State = EntityState.Unchanged);
                return context.SaveChanges() > 0;
            }
        }
    }
}
