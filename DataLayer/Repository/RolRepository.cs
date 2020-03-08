using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class RolRepository : BaseRepository<Rol>, IRolesRepository
    {
        public List<Rol> GetRolesUser(int id)
        {
            using (ModelContainer1 container1 = new ModelContainer1())
            {
                return container1.ClienteSet.Single(u => u.Id == id)?.Rol.ToList();
            };
        }
    }
}
