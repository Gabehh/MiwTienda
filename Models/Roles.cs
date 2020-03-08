using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiwTienda.Models
{
    public class Roles
    {
        public enum RolUser: int
        {
            Admin = 1,
            User = 2
        }
    }
}