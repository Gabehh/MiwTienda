using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiwTienda.Models
{
    public class PedidoViewModels
    {
        public Cliente cliente { get; set; }
        [Display(Name="Metodos de pago:")]
        public List<MetodoPago> metodoPago { get; set; }
        [Display(Name = "Titular de la tarjeta:")]
        public string titular { get; set; }
        [Display(Name = "Número de Tarjeta")]
        public int numero { get; set; }
        [Display(Name = "Mes de caducidad")]
        public string caducidad { get; set; }
        [Display(Name = "Código CVC2")]
        public string codigo { get; set; }
        public int methodPay { get; set; }
    }
}