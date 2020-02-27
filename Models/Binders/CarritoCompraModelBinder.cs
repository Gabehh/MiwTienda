using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiwTienda.Models.Binders
{
    public class CarritoCompraModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CarritoCompra cc = (controllerContext.HttpContext.Session != null) ?
                (controllerContext.HttpContext.Session["key_cc"] as CarritoCompra) :
                 null;

            if (cc == null)
            {
                cc = new CarritoCompra();
                controllerContext.HttpContext.Session["key_cc"] = cc;
            }

            return cc;
        }
    }
}