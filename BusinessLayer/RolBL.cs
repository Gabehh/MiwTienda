using DataLayer.Model;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RolBL
    {
        public List<Rol> GetRolesByUser(int idCliente)
        {
            RolRepository rolRepository = new RolRepository();
            return rolRepository.GetRolesUser(idCliente);
        }
    }
}
