using DataLayer.Model;
using System;
using System.Collections.Generic;
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
    }
}
